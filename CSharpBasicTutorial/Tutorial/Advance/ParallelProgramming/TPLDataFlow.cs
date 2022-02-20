using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CSharpTutorial.Tutorial.Advance;

public class TPLDataFlow
{
    public class Sample
    {
        public void BufferBlock()
        {
            var bufferBlock = new BufferBlock<int>();

            // Post several messages to the block.
            for (int i = 0; i < 3; i++) bufferBlock.Post(i);
            
            // Receive the messages back from the block.
            for (int i = 0; i < 3; i++) Console.WriteLine(bufferBlock.Receive());

            // TryReceive 를 통해 읽을수도 있다. 
            //while (bufferBlock.TryReceive(out int value)) Console.WriteLine(value);

            // Output:
            //   0
            //   1
            //   2

        }

        public async void BufferBlockWithTask()
        {
            var bufferBlock = new BufferBlock<int>();

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() =>
            {
                bufferBlock.Post(0);
                bufferBlock.Post(1);
            }));
            
            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < 3; i++) Console.WriteLine(bufferBlock.Receive());
            }));

            tasks.Add(Task.Run(() => bufferBlock.Post(2)));

            await Task.WhenAll(tasks);

            // Output:
            //   0
            //   1
            //   2
        }

        public async void BufferBlockAsync()
        {
            var bufferBlock = new BufferBlock<int>();
            // Post more messages to the block asynchronously.
            for (int i = 0; i < 3; i++) await bufferBlock.SendAsync(i);
            // Asynchronously receive the messages back from the block.
            for (int i = 0; i < 3; i++) Console.WriteLine(await bufferBlock.ReceiveAsync());

            // Output:
            //   0
            //   1
            //   2
        }

        public async void ProduceConsumerModel()
        {
            var buffer = new BufferBlock<byte[]>();
            var consumerTask = ConsumeAsync(buffer);
            Produce(buffer);

            var bytesProcessed = await consumerTask;

            Console.WriteLine($"Processed {bytesProcessed:#,#} bytes.");

        }

        private void Produce(ITargetBlock<byte[]> target)
        {
            var rand = new Random();

            for (int i = 0; i < 100; ++i)
            {
                var buffer = new byte[1024];
                rand.NextBytes(buffer);
                target.Post(buffer);
            }

            target.Complete();
        }

        private async Task<int> ConsumeAsync(ISourceBlock<byte[]> source)
        {
            int bytesProcessed = 0;

            while (await source.OutputAvailableAsync())
            {
                byte[] data = await source.ReceiveAsync();
                bytesProcessed += data.Length;
            }

            return bytesProcessed;
        }

        private async Task<int> ConsumeAsync(IReceivableSourceBlock<byte[]> source)
        {
            int bytesProcessed = 0;
            while (await source.OutputAvailableAsync())
            {
                while (source.TryReceive(out byte[] data))
                {
                    bytesProcessed += data.Length;
                }
            }
            return bytesProcessed;
        }

        public void DataBlockAndPipeLine()
        {

            var downloadString = new TransformBlock<string, string>(async uri =>
            {
                Console.WriteLine("Downloading '{0}'...", uri);

                return await new HttpClient(new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.GZip }).GetStringAsync(uri);
            });

            // Separates the specified text into an array of words.
            var createWordList = new TransformBlock<string, string[]>(text =>
            {
                Console.WriteLine("Creating word list...");

                // Remove common punctuation by replacing all non-letter characters
                // with a space character.
                char[] tokens = text.Select(c => char.IsLetter(c) ? c : ' ').ToArray();
                text = new string(tokens);

                // Separate the text into an array of words.
                return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            });

            // Removes short words and duplicates.
            var filterWordList = new TransformBlock<string[], string[]>(words =>
            {
                Console.WriteLine("Filtering word list...");

                return words
                   .Where(word => word.Length > 3)
                   .Distinct()
                   .ToArray();
            });

            // Finds all words in the specified collection whose reverse also
            // exists in the collection.
            var findReversedWords = new TransformManyBlock<string[], string>(words =>
            {
                Console.WriteLine("Finding reversed words...");

                var wordsSet = new HashSet<string>(words);

                return from word in words.AsParallel()
                       let reverse = new string(word.Reverse().ToArray())
                       where word != reverse && wordsSet.Contains(reverse)
                       select word;
            });

            // Prints the provided reversed words to the console.
            var printReversedWords = new ActionBlock<string>(reversedWord =>
            {
                Console.WriteLine("Found reversed words {0}/{1}",
                   reversedWord, new string(reversedWord.Reverse().ToArray()));
            });

            //
            // Connect the dataflow blocks to form a pipeline.
            //

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            downloadString.LinkTo(createWordList, linkOptions);
            createWordList.LinkTo(filterWordList, linkOptions);
            filterWordList.LinkTo(findReversedWords, linkOptions);
            findReversedWords.LinkTo(printReversedWords, linkOptions);

            // Process "The Iliad of Homer" by Homer.
            downloadString.Post("http://www.gutenberg.org/cache/epub/16452/pg16452.txt");

            // Mark the head of the pipeline as complete.
            downloadString.Complete();

            // Wait for the last block in the pipeline to process all messages.
            printReversedWords.Completion.Wait();
        }

    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();
            //sample.BufferBlock();
            //sample.BufferBlockWithTask();
            //sample.BufferBlockAsync();
            //sample.ProduceConsumerModel();
            sample.DataBlockAndPipeLine();

            Console.ReadLine();
        }
    }
}
