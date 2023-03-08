
// 5 visitors in queue in front of Club
for (int i = 1; i < 6; i++)
{
    Person person = new Person(i);
}

Console.ReadKey();

class Person
{
    // semaphore 
    static Semaphore sem = new Semaphore(3, 100); // 3 from 100 places are available now
    Thread myThread;
    int count = 1;// visits counter for every person

    public Person(int i)
    {
        myThread = new Thread(Club);
        myThread.Name = $"Visitor {i}";
        myThread.Start();
    }
    public void Club()
    {
        while (count > 0)
        {
            sem.WaitOne();  // waiting for place

            Console.WriteLine($"{Thread.CurrentThread.Name} is entering in Club");

            Console.WriteLine($"{Thread.CurrentThread.Name} dancing");
            Thread.Sleep(2000);

            Console.WriteLine($"{Thread.CurrentThread.Name} leaving Club");

            sem.Release();  // making room for new person

            count--;
            Thread.Sleep(1000);
        }
    }
}

