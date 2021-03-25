using Scenes.Game.Scripts.Elemek;

namespace Scenes.Game.Scripts.Structs
{
    public struct Mentes
    {
        //terem
        public int sor;
        public int oszlop;
        public bool duplaPad;
        
        public bool egyhelykihagy;
        public bool randomulesrend;
        public int tanulokszama;
        public int puskazokszama;
        public int playerPadid;
        
     public Elem[,] Grid;
        
    
//asztal
        public bool frontPanel;
        public bool sidePanel;
        public bool monitor;
//exam
        public int QuestionsNumber;
        public int QuestionsNumberExam;
        public int questionLength;
        public int questionTime;
        public int subject;
        //tanar
        public int alertness;
        public int frontBack;
        public int walking;
        public int agressiveness;
        public int eyes; 
        public int speed; 
              
        public int karma; 
        //cheating strategy
        public int prepareTimeLimit;
  
        
        
        
        
      //  locked
        public bool sorLocked;
        public bool oszlopLocked;
        public bool egyhelykihagyLocked;
        public bool randomulesrendLocked;
        public bool duplaPadLocked;
        public bool tanulokszamaLocked;
        public bool puskazokszamaLocked;
        public bool playerPadidLocked;
    
//asztal
        public bool frontPanelLocked;
        public bool sidePanelLocked;
        public bool monitorLocked;
//exam
        public bool QuestionsNumberLocked;
        public bool QuestionsNumberExamLocked;
        public bool questionLengthLocked;
        public bool questionTimeLocked;
        public bool subjectLocked;
        public bool  electronicDevicesLocked;
        public bool calculatorLocked;
        public bool secondChanceLocked;
        //tanar
        public bool alertnessLocked;
        public bool frontBackLocked;
        public bool walkingLocked;
        public bool agressivenessLocked;
        public bool eyesLocked; 
        public bool speedLocked; 
        
        public bool karmaLocked; 
        //cheating strategy
        public bool prepareTimeLimitLocked;
        
        
        
        
    }
}