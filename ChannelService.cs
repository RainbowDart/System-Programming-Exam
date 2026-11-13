using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SystemUtilitySuite
{
    public class ChannelService
    {
        // TODO 10: Добавить ограниченный Channel pipeline.
        public async Task RunPipelineAsync()
        {
            var channel = Channel.CreateBounded<int>(5);

            var producer = Task.Run(async () =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    await channel.Writer.WriteAsync(i);
                    Console.WriteLine($"Записано: {i}");
                }
                channel.Writer.Complete();
            });

            var consumer = Task.Run(async () =>
            {
                await foreach (var item in channel.Reader.ReadAllAsync())
                {
                    Console.WriteLine($"Прочитано: {item}");
                }
            });

            await Task.WhenAll(producer, consumer);
        }
    }
}
