using System;

namespace DotnetSandbox
{
    public abstract class FinalizeDay
    {
        public abstract ProgramModule ProgramModule { get; set; }

        public abstract void FinalizeDayInBank();
    }

    public class CardsFinalizeDay : FinalizeDay
    {
        public override ProgramModule ProgramModule { get; set; } = ProgramModule.Cards;
        
        public override void FinalizeDayInBank()
        {
            Console.WriteLine("Withdraw with IPC");
            Console.WriteLine("Calculate overdraft");
        }
    }
    
    
    public class DepositsFinalizeDay : FinalizeDay
    {
        public override ProgramModule ProgramModule { get; set; } = ProgramModule.Deposits;
        
        public override void FinalizeDayInBank()
        {
           
        }
    }
}