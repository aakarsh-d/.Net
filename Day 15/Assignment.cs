using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraEnterpriseSDLC
{
    public enum RiskLevel
    {
        Low,
        Medium,
        High,
        Critical
    }

    public enum SDLCStage
    {
        Backlog = 1,
        Requirement,
        Design,
        Development,
        CodeReview,
        Testing,
        UAT,
        Deployment,
        Maintenance
    }

    sealed class Requirement
    {
        public int Id { get; }
        public string Title { get; }
        public RiskLevel Risk { get; }

        public Requirement(int id, string title, RiskLevel risk)
        {
            Id = id;
            Title = title;
            Risk = risk;
        }
    }

    public sealed class WorkItem
    {
        public int Id { get; }
        public string Name { get; }
        public SDLCStage Stage { get; set; }
        public HashSet<int> DependencyIds { get; }

        public WorkItem(int id, string name, SDLCStage stage)
        {
            Id = id;
            Name = name;
            Stage = stage;
            DependencyIds = new HashSet<int>();
        }
    }

    sealed class BuildSnapshot
    {
        public string Version { get; }
        public DateTime Timestamp { get; }

        public BuildSnapshot(string version)
        {
            Version = version;
            Timestamp = DateTime.Now;
        }
    }

    sealed class AuditLog
    {
        public DateTime Time { get; }
        public string Action { get; }

        public AuditLog(string action)
        {
            Action = action;
            Time = DateTime.Now;
        }
    }

    sealed class QualityMetric
    {
        public string Name { get; }
        public double Score { get; }

        public QualityMetric(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }

    public class EnterpriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int, WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage, List<WorkItem>> _stageBoard;
        private Queue<WorkItem> _executionQueue;
        private Stack<BuildSnapshot> _rollbackStack;
        private HashSet<string> _uniqueTestSuites;
        private LinkedList<AuditLog> _auditLedger;
        private SortedList<double, QualityMetric> _releaseScoreboard;

        private int _requirementCounter;
        private int _workItemCounter;

        public EnterpriseSDLCEngine()
        {
            _requirements = new List<Requirement>();
            _workItemRegistry = new Dictionary<int, WorkItem>();
            _stageBoard = new SortedDictionary<SDLCStage, List<WorkItem>>();

            foreach (SDLCStage stage in Enum.GetValues(typeof(SDLCStage)))
            {
                _stageBoard[stage] = new List<WorkItem>();
            }

            _executionQueue = new Queue<WorkItem>();
            _rollbackStack = new Stack<BuildSnapshot>();
            _uniqueTestSuites = new HashSet<string>();
            _auditLedger = new LinkedList<AuditLog>();
            _releaseScoreboard = new SortedList<double, QualityMetric>();
        }

        public void AddRequirement(string title, RiskLevel risk)
        {
            Requirement requirement = new Requirement(_requirementCounter, title, risk);
            _requirementCounter++;

            _requirements.Add(requirement);
            _auditLedger.AddLast(new AuditLog("Requirement added"));
        }

        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            WorkItem workItem = new WorkItem(_workItemCounter, name, stage);
            _workItemCounter++;

            _workItemRegistry.Add(workItem.Id, workItem);
            _stageBoard[stage].Add(workItem);

            _auditLedger.AddLast(new AuditLog("WorkItem created"));
            return workItem;
        }

        public void AddDependency(int workItemId, int dependsOnId)
        {
            if (!_workItemRegistry.ContainsKey(workItemId) ||
                !_workItemRegistry.ContainsKey(dependsOnId))
                return;

            _workItemRegistry[workItemId].DependencyIds.Add(dependsOnId);
            _auditLedger.AddLast(new AuditLog("Dependency added"));
        }

        public void PlanStage(SDLCStage stage)
        {
            var eligibleItems =
                _stageBoard[stage]
                .Where(item =>
                    item.DependencyIds.All(depId =>
                        _workItemRegistry[depId].Stage > stage));

            foreach (var item in eligibleItems)
            {
                _executionQueue.Enqueue(item);
            }

            _auditLedger.AddLast(new AuditLog("Stage planned"));
        }

        public void ExecuteNext()
        {
            if (_executionQueue.Count == 0)
                return;

            WorkItem item = _executionQueue.Dequeue();
            SDLCStage previousStage = item.Stage;

            item.Stage = (SDLCStage)((int)item.Stage + 1);

            _stageBoard[previousStage].Remove(item);
            _stageBoard[item.Stage].Add(item);

            _auditLedger.AddLast(new AuditLog("WorkItem executed"));
        }

        public void RegisterTestSuite(string suiteId)
        {
            _uniqueTestSuites.Add(suiteId);
            _auditLedger.AddLast(new AuditLog("Test suite registered"));
        }

        public void DeployRelease(string version)
        {
            BuildSnapshot snapshot = new BuildSnapshot(version);
            _rollbackStack.Push(snapshot);

            _auditLedger.AddLast(new AuditLog("Release deployed"));
        }

        public void RollbackRelease()
        {
            if (_rollbackStack.Count == 0)
                return;

            BuildSnapshot snapshot = _rollbackStack.Pop();
            _auditLedger.AddLast(new AuditLog("Rollback executed"));
        }

        public void RecordQualityMetric(string metricName, double score)
        {
            if (_releaseScoreboard.ContainsKey(score))
                return;

            _releaseScoreboard.Add(score, new QualityMetric(metricName, score));
        }

        public void PrintAuditLedger()
        {
            foreach (var log in _auditLedger)
            {
                Console.WriteLine($"{log.Time}: {log.Action}");
            }
        }

        public void PrintReleaseScoreboard()
        {
            foreach (var entry in _releaseScoreboard.Reverse())
            {
                Console.WriteLine($"{entry.Value.Name} - {entry.Key:F2}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            EnterpriseSDLCEngine engine = new EnterpriseSDLCEngine();

            engine.AddRequirement("Single Sign-On", RiskLevel.High);
            engine.AddRequirement("Fraud Detection", RiskLevel.Critical);

            WorkItem design = engine.CreateWorkItem("Design SSO", SDLCStage.Design);
            WorkItem dev = engine.CreateWorkItem("Develop SSO", SDLCStage.Development);
            WorkItem test = engine.CreateWorkItem("Test SSO", SDLCStage.Testing);

            engine.AddDependency(dev.Id, design.Id);
            engine.AddDependency(test.Id, dev.Id);

            engine.RegisterTestSuite("SSO-Regression");
            engine.RegisterTestSuite("SSO-Security-Smoke");

            engine.PlanStage(SDLCStage.Design);
            engine.ExecuteNext();
            engine.ExecuteNext();

            engine.DeployRelease("v3.4.1");

            engine.RecordQualityMetric("Code Coverage", 91.7);
            engine.RecordQualityMetric("Security Score", 97.3);

            engine.RollbackRelease();

            engine.PrintAuditLedger();
            engine.PrintReleaseScoreboard();
        }
    }
}
