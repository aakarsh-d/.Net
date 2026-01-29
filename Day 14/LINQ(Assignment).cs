using Microsoft.VisualBasic;

namespace AutonomousRobot.AI
{
    public class SensorReading
    {
        public int SensorId{ get; set;}
        public string Type{ get; set;}
        public double Value{ get; set;}
        public DateTime Timestamp{ get; set;}
        public double Confidence{ get; set;}
    }
        public enum RobotAction{
            Stop, SlowDown, Reroute, Continue
        }

    

    class DecisionEngine
    {
        public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory, DateTime fromTime)
        {
            return sensorHistory.Where(s=>s.Timestamp>=fromTime).ToList();
        }

        public bool IsBatteryCritical(List<SensorReading> readings)
        {
            return readings.Any(s=>s.Type=="Battery" && s.Value<20);
        }
        public double GetNearestObstacleDistance(List<SensorReading> readings)
        {
            var distances = readings
                .Where(r => r.Type == "Distance")
                .Select(r => r.Value);

            return distances.Any() ? distances.Min() : double.MaxValue;
        }

        public bool isTemperatureSafe(List<SensorReading> readings)
        {
            return readings.Where(s=>s.Type=="Temperature").All(s=>s.Value<90);
        }

        public double GetAverageVibration(List<SensorReading> readings)
        {
            var result=readings.Where(s=>s.Type=="Vibration").Select(s=>s.Value);
            return result.Any()?result.Average():0;
            // if (result.Any())
            // {
            //     return result.Average();
            // }
            // return 0;
        }

        public Dictionary<string,double> CalculateSensorHealth(List<SensorReading> sensorHistory)
        {
            return sensorHistory.GroupBy(s=>s.Type).ToDictionary(g=>g.Key,g=>g.Average(s=>s.Confidence));
        }

        public List<string> DetectFaultySensors(List<SensorReading> sensorHistory)
        {
            return sensorHistory.GroupBy(s=>s.Type).Where(g=>g.Count(s=>s.Confidence<0.4)>2).Select(g=>g.Key).ToList();
        }

        public bool IsBatteryDrainingFast(List<SensorReading> sensorHistory)
        {
            var batteryreadings= sensorHistory.Where(r=>r.Type=="Battery").OrderBy(r=>r.Timestamp).Select(r=>r.Value).ToList();
            return batteryreadings.Zip(batteryreadings.Skip(1),(prev,next)=>next<prev).All(result=>result);
        }
        public double GetWeightedDistance(List<SensorReading> readings)
        {
            var res=readings.Where(r=>r.Type=="Distance").ToList();
            double weightedsum=res.Sum(r=>r.Value*r.Confidence);

            double TotalConfidencevalue=res.Sum(r=>r.Confidence);

            if(TotalConfidencevalue==0) return double.MaxValue;

            return weightedsum/TotalConfidencevalue;

        }

        public RobotAction DecideRobotAction(List<SensorReading> recentReadings, List<SensorReading> sensorHistory)
        {
            if(IsBatteryCritical(recentReadings)) return RobotAction.Stop;
            if(IsBatteryDrainingFast(sensorHistory)) return RobotAction.Stop;
            if(GetNearestObstacleDistance(recentReadings)<1.0) return RobotAction.Reroute;

            if(!isTemperatureSafe(recentReadings)) return RobotAction.SlowDown;

            return RobotAction.Continue;

        }
    }


    class Program
    {
        static void Main()
        {
            List<SensorReading> sensorHistory=new List<SensorReading>
            {
                new SensorReading{ SensorId=1,Type="Distance",Value=0.8,Confidence=0.9,Timestamp=DateTime.Now.AddSeconds(-8)},
                new SensorReading{ SensorId=1,Type="Battery",Value=18,Confidence=0.8,Timestamp=DateTime.Now.AddSeconds(-8)},
                new SensorReading{ SensorId=1,Type="Temperature",Value=92,Confidence=0.7,Timestamp=DateTime.Now.AddSeconds(-6)},
                new SensorReading{ SensorId=1,Type="Vibration",Value=8.2,Confidence=0.6,Timestamp=DateTime.Now.AddSeconds(-5)},
                new SensorReading{ SensorId=1,Type="Battery",Value=75,Confidence=0.9,Timestamp=DateTime.Now.AddSeconds(-4)},
                new SensorReading{ SensorId=1,Type="Distance",Value=2.5,Confidence=0.5,Timestamp=DateTime.Now.AddSeconds(-3)},
            };

            DecisionEngine engine=new DecisionEngine();

            var recentReadings = engine.GetRecentReadings(sensorHistory, DateTime.Now.AddSeconds(-10));

    // TASK 2: IsBatteryCritical
    bool isBatteryCritical =engine.IsBatteryCritical(recentReadings);
    Console.WriteLine($"Task 2 - Battery Critical: {isBatteryCritical}");

    // TASK 3: GetNearestObstacleDistance
    double nearestObstacle = engine.GetNearestObstacleDistance(recentReadings);
    Console.WriteLine($"Task 3 - Nearest Obstacle Distance: {nearestObstacle}");

    // TASK 4: IsTemperatureSafe
    bool isTemperatureSafe = engine.isTemperatureSafe(recentReadings);
    Console.WriteLine($"Task 4 - Temperature Safe: {isTemperatureSafe}");

    // TASK 5: GetAverageVibration
    double averageVibration = engine.GetAverageVibration(recentReadings);
    Console.WriteLine($"Task 5 - Average Vibration: {averageVibration}");

    // TASK 6: CalculateSensorHealth
    var sensorHealth = engine.CalculateSensorHealth(sensorHistory);
    Console.WriteLine("Task 6 - Sensor Health:");
    foreach (var h in sensorHealth) Console.WriteLine($"{h.Key} -> {h.Value}");

    // TASK 7: DetectFaultySensors
    var faultySensors = engine.DetectFaultySensors(sensorHistory);
    Console.WriteLine("Task 7 - Faulty Sensors:");
    Console.WriteLine(faultySensors.Count == 0 ? "None" : string.Join(", ", faultySensors));

    // TASK 8: IsBatteryDrainingFast
    bool isBatteryDrainingFast = engine.IsBatteryDrainingFast(sensorHistory);
    Console.WriteLine($"Task 8 - Battery Draining Fast: {isBatteryDrainingFast}");

    // TASK 9: GetWeightedDistance
    double weightedDistance = engine.GetWeightedDistance(recentReadings);
    Console.WriteLine($"Task 9 - Weighted Distance: {weightedDistance}");

    // TASK 10: DecideRobotAction
    RobotAction action = engine.DecideRobotAction(recentReadings, sensorHistory);
    Console.WriteLine($"Robot Action: {action}");
        }
    }
       
}