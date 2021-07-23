using Resources.Game.Elemek.GridElements;

namespace Resources.Game.DataClassok
{
    public struct GameData
    {
         
        public Elem[,] Grid;
        
        
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
       
    }
}