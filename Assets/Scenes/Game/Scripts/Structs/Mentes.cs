using Scenes.Game.Scripts.Elemek;

namespace Scenes.Game.Scripts.Structs
{
    public struct Mentes
    {
        //terem
        public int sor;
        public int oszlop;
        public bool egyhelykihagy;
        public bool randomulesrend;
        public int tanulokszama;
        public int puskazokszama;
        public bool duplaPad;
// a gridet mentsuk el vagy a beallitasokat vagy mindkettot?
        public Elem[,] Grid;
        
        public int playerPadid;
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
        public bool  electronicDevices;
        public bool calculator;
        public bool secondChance;
        //tanar
        public int alertness;
        public int frontBack;
        public int walking;
        public int agressiveness;
        public int eyes; 
        public int speed; 
        //cheating strategy
        public int prepareTimeLimit;
    }
}