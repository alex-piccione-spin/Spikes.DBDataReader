using Betting.Spikes.DataReader.Builders;
using Betting.Spikes.DataReader.Readers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Betting.Spikes.DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfAccounts = int.Parse(ConfigurationManager.AppSettings["numberOfAccounts"]);

            ISourceConnection connection = new Connection();
            IAccountBuilder accountBuilder = new AccountBuilder();
            IAccountBuilder newAccountBuilder = new NewAccountBuilder();
            IAccountBuilder newAccountBuilderUsingOrdinals = new NewAccountBuilderUsingOrdinals();
            IAccountReader actualReader = new ActualReader(connection, accountBuilder);
            IAccountReader newReader = new NewReader(connection, accountBuilder);
            IAccountReader newReader_2 = new NewReader(connection, newAccountBuilder);
            IAccountReader newReader_3 = new NewReader(connection, newAccountBuilderUsingOrdinals);
            //IAccountReader[] readers = GetReaders();

            Console.WriteLine($"Read {numberOfAccounts} accounts");

            Stopwatch watch;
            IList<Account> accounts;

            // ActualReader
            watch = Stopwatch.StartNew();
            accounts = actualReader.Read();
            watch.Stop();
            var actualReaderTime = watch.Elapsed;

            Thread.Sleep(1000 * 15);

            // NewReader
            watch = Stopwatch.StartNew();
            accounts = newReader.Read();
            watch.Stop();
            var newReaderTime = watch.Elapsed;

            Thread.Sleep(1000 * 15);

            // NewReader + NewAccountBuilder
            watch = Stopwatch.StartNew();
            accounts = newReader_2.Read();
            watch.Stop();
            var newReader_2_Time = watch.Elapsed;

            Thread.Sleep(1000 * 15);

            // NewReader + NewAccountBuilderUsingOrdinals
            watch = Stopwatch.StartNew();
            accounts = newReader_3.Read();
            watch.Stop();
            var newReader_3_Time = watch.Elapsed;



            Console.WriteLine($"Actual reader finished in {Math.Round(actualReaderTime.TotalSeconds, 3)} seconds");
            Console.WriteLine($"New reader finished in {Math.Round(newReaderTime.TotalSeconds, 3)} seconds");
            Console.WriteLine($"New reader and new builder finished in {Math.Round(newReader_2_Time.TotalSeconds, 3)} seconds");
            Console.WriteLine($"New reader and new builder using ordinals finished in {Math.Round(newReader_3_Time.TotalSeconds, 3)} seconds");

            Console.Write("\n\nPress any key to close...");
            Console.Read();
        }

    }
}
