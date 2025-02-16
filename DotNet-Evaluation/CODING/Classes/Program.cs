class Program
{
    static void Main()
    {
        StockPortfolio portfolio = new();
        portfolio.AddStock("AAPL", 150.5);
        portfolio.AddStock("GOOGL", 2800);
        portfolio.RemoveStock("AAPL");
        Console.WriteLine({portfolio.TotalValue()});

        SmartHomeSystem home = new();
        home.AddDevice("Light");
        home.AddDevice("Fan");
        home.RemoveDevice("Fan");
        home.ToggleAll(true);

        TaskScheduler scheduler = new();
        scheduler.AddTask("Task 1");
        scheduler.AddTask("Task 2");
        scheduler.ExecuteTask();
        scheduler.ExecuteTask();
        scheduler.ExecuteTask();

        BlockchainTransaction transaction = new() { Sender = "Alice", Receiver = "Bob", Amount = 100.5 };
        Console.WriteLine({transaction.Hash});

        MusicPlaylist playlist = new();
        playlist.AddSong("Song 1");
        playlist.AddSong("Song 2");
        playlist.PlayAll();
    }
}

class StockPortfolio
{
    private Dictionary<string, double> stocks = new();
    public void AddStock(string symbol, double price) => stocks[symbol] = price;
    public void RemoveStock(string symbol) => stocks.Remove(symbol);
    public double TotalValue() => stocks.Values.Sum();
}

class SmartHomeSystem
{
    private List<string> devices = new();
    public void AddDevice(string device) => devices.Add(device);
    public void RemoveDevice(string device) => devices.Remove(device);
    public void ToggleAll(bool state) => Console.WriteLine(state ? "All devices ON" : "All devices OFF");
}

class TaskScheduler
{
    private Queue<string> tasks = new();
    public void AddTask(string task) => tasks.Enqueue(task);
    public void ExecuteTask() => Console.WriteLine(tasks.Count > 0 ? $"Executing: {tasks.Dequeue()}" : "No tasks left");
}


class Song
{
    public string Title { get; set; }
    public Song Next { get; set; }
    public Song Prev { get; set; }
    public Song(string title) => Title = title;
}

