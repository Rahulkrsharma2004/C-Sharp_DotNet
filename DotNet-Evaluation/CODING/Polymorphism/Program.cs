
abstract class DatabaseConnector
{
    public abstract void Connect();
}

class SQLDatabase : DatabaseConnector
{
    public override void Connect() => Console.WriteLine("Connected to SQL Database.");
}

class MongoDB : DatabaseConnector
{
    public override void Connect() => Console.WriteLine("Connected to MongoDB.");
}

class Firebase : DatabaseConnector
{
    public override void Connect() => Console.WriteLine("Connected to Firebase.");
}


abstract class AIModel
{
    public abstract void TrainModel();
}

class BasicAI : AIModel
{
    public override void TrainModel() => Console.WriteLine("Training Basic AI Model...");
}

class NeuralNet : AIModel
{
    public override void TrainModel() => Console.WriteLine("Training Neural Network...");
}

class DeepLearning : AIModel
{
    public override void TrainModel() => Console.WriteLine("Training Deep Learning Model...");
}

abstract class GamePhysicsEngine
{
    public abstract void Simulate();
}

class Physics2D : GamePhysicsEngine
{
    public override void Simulate() => Console.WriteLine("Simulating 2D Game Physics...");
}

class Physics3D : GamePhysicsEngine
{
    public override void Simulate() => Console.WriteLine("Simulating 3D Game Physics...");
}

class Program
{
    static void Main()
    {
        ExpressionEvaluator exp1 = new(5);
        ExpressionEvaluator exp2 = new(10);
        ExpressionEvaluator result = exp1 + exp2;
        Console.WriteLine({result});
        DatabaseConnector db = new SQLDatabase();
        db.Connect();
        db = new MongoDB();
        db.Connect();
        db = new Firebase();
        db.Connect();
        FileCompressor compressor = new();
        compressor.Compress("Sample text");
        compressor.Compress(new byte[] { 1, 2, 3 });
        compressor.Compress("video.mp4", 1200);
        AIModel ai = new BasicAI();
        ai.TrainModel();
        ai = new NeuralNet();
        ai.TrainModel();
        ai = new DeepLearning();
        ai.TrainModel();
        GamePhysicsEngine physics = new Physics2D();
        physics.Simulate();
        physics = new Physics3D();
        physics.Simulate();
    }
}
