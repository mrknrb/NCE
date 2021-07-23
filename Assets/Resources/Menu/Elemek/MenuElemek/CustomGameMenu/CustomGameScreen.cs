using Resources.Game.DataClassok;
using Resources.Menu.Elemek.MenuElemek.CustomGameMenu.ClassRoomMap;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Resources.Menu.Elemek.MenuElemek.CustomGameMenu
{
    public class CustomGameScreen : MonoBehaviour
    {
        private Mentes mentesEredeti;

        public static Mentes mentesModositott;
        public ClassRoomMapObject classRoomMapObject;

        //classroom

        public Slider columnCountSlider;
        public Slider rowCountSlider;
        public Toggle doubleTables;

        public Toggle egyHelyKihagy;
        public Toggle randomSitting;

        public Slider studentCountSlider;
        public Slider cheaterCountSlider;

        public Toggle frontPanel;
        public Toggle sidePanel;
        public Toggle monitor;
      
        //exam
        public Slider QuestionsNumber;
        public Slider QuestionsNumberExam;
        public Slider questionLength;
        public Slider ExamQuestionTime;
        public Slider PrepareQuestionTime;
        public TMP_Dropdown subject;
      

        //teacher
        public Slider alertness;
        public Slider frontBack;
        public Slider walking;
        public Slider agressiveness;
        public Slider karma;
        public Slider eyes;
        public Slider speed;

//cheating methods
        public Button StartMissionButton;
        
        void Start()
        {
            
            mentesEredeti = new Mentes();
            mentesModositott=new Mentes();
            classRoomMapObject=new ClassRoomMapObject();
            mentesModositott = classRoomMapObject.elemekGridObject.mentes;
            mentesModositottFrissites();
            classRoomMapObject. frissitMentessel(mentesModositott);
            eventListenerInit();
            
            StartMissionButton.onClick.AddListener(delegate
            {
               
                mentesModositottFrissites();
                SceneManager.LoadScene("Resources/Game/Game", LoadSceneMode.Single);
            });
        }

        private void eventListenerInit()
        {
            columnCountSlider.onValueChanged.AddListener(delegate
            {
                mentesModositottFrissites();
                classRoomMapObject.frissitMentessel(mentesModositott);
            });
            rowCountSlider.onValueChanged.AddListener(delegate
            {
                mentesModositottFrissites();
                classRoomMapObject.frissitMentessel(mentesModositott);
            });
            doubleTables.onValueChanged.AddListener(delegate
            {
                mentesModositottFrissites();
                classRoomMapObject.frissitMentessel(mentesModositott);
            });
            egyHelyKihagy.onValueChanged.AddListener(delegate
            {
                mentesModositottFrissites();
                classRoomMapObject.frissitMentessel(mentesModositott);
            });
            randomSitting.onValueChanged.AddListener(delegate
            {
                mentesModositottFrissites();
                classRoomMapObject.frissitMentessel(mentesModositott);
            });
            studentCountSlider.onValueChanged.AddListener(delegate
            {
                mentesModositottFrissites();
                classRoomMapObject.frissitMentessel(mentesModositott);
            });
            cheaterCountSlider.onValueChanged.AddListener(delegate
            {
                mentesModositottFrissites();
                classRoomMapObject.frissitMentessel(mentesModositott);
            });
            frontPanel.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            sidePanel.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            monitor.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });


            QuestionsNumber.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            QuestionsNumberExam.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            questionLength.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            ExamQuestionTime.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            
            PrepareQuestionTime.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            subject.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
        
            alertness.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            frontBack.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            walking.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            agressiveness.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            karma.onValueChanged.AddListener(delegate { mentesModositottFrissites(); }); //nem tanartulajdonsag
            eyes.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
            speed.onValueChanged.AddListener(delegate { mentesModositottFrissites(); });
        }

        private void mentesModositottFrissites()
        {
            mentesModositott.sor = (int) rowCountSlider.value;
            mentesModositott.oszlop = (int) columnCountSlider.value * 2;
            mentesModositott.duplaPad = doubleTables.isOn;
            
            mentesModositott.egyhelykihagy = egyHelyKihagy.isOn;
            mentesModositott.randomulesrend = randomSitting.isOn;
            mentesModositott.tanulokszama = (int) studentCountSlider.value;
            mentesModositott.puskazokszama = (int) cheaterCountSlider.value;

            //mentesModositott.playerPadid = 7;
            //pad
            mentesModositott.frontPanel = frontPanel.isOn;
            mentesModositott.sidePanel = sidePanel.isOn;
            mentesModositott.monitor = monitor.isOn;
            //exam
            mentesModositott.QuestionsNumber = (int) QuestionsNumber.value;
            mentesModositott.QuestionsNumberExam = (int) QuestionsNumberExam.value;
            mentesModositott.questionLength = (int) questionLength.value;
            mentesModositott.ExamQuestionTime = (int) ExamQuestionTime.value;
            
            mentesModositott.PrepareQuestionTime = (int) PrepareQuestionTime.value;
            mentesModositott.subject = subject.value;
           
            //Tanar tulajdonsagok
            mentesModositott.alertness = (int) alertness.value;
            mentesModositott.frontBack = (int) frontBack.value;
            mentesModositott.walking = (int) walking.value;
            mentesModositott.agressiveness = (int) agressiveness.value;
            mentesModositott.eyes = (int) eyes.value;
            mentesModositott.speed = (int) speed.value;
        }

        public void mentesBetoltes(Mentes mentes)
        {
            mentesEredeti = mentes;
            mentesModositott = mentes;
            doubleTables.isOn = mentes.duplaPad;
            rowCountSlider.value = mentes.sor;
            columnCountSlider.value = mentes.oszlop / 2;
          
            egyHelyKihagy.isOn = mentes.egyhelykihagy;
            randomSitting.isOn = mentes.randomulesrend;
           
            studentCountSlider.value = mentes.tanulokszama;
            cheaterCountSlider.value = mentes.puskazokszama;

            // mentes.playerPadid = 10;
            //pad
            frontPanel.isOn = mentes.frontPanel;
            sidePanel.isOn = mentes.sidePanel;
            monitor.isOn = mentes.monitor;
            //exam
            QuestionsNumber.value = mentes.QuestionsNumber;
            QuestionsNumberExam.value = mentes.QuestionsNumberExam;
            questionLength.value = mentes.questionLength;
            ExamQuestionTime.value = mentes.ExamQuestionTime;
            PrepareQuestionTime.value = mentes.PrepareQuestionTime;
            subject.value = mentes.subject;
        
            //Tanar tulajdonsagok
            alertness.value = mentes.alertness;
            frontBack.value = mentes.frontBack;
            walking.value = mentes.walking;
            agressiveness.value = mentes.agressiveness;
            eyes.value = mentes.eyes;
            speed.value = mentes.speed;
            //classRoomScript.frissit(mentes);
            karma.value = mentes.karma;
            
            //locks
            rowCountSlider.GetComponent<CsuszdaElemMrk>().Locker(mentes.sorLocked);
            columnCountSlider.GetComponent<CsuszdaElemMrk>().Locker(mentes.oszlopLocked);
             doubleTables.GetComponent<ValasztoBool>().Locker(mentes.duplaPadLocked); 
             
            egyHelyKihagy.GetComponent<ValasztoBool>().Locker(mentes.egyhelykihagyLocked);
            randomSitting.GetComponent<ValasztoBool>().Locker(mentes.randomulesrendLocked);

            studentCountSlider.GetComponent<CsuszdaElemMrk>().Locker(mentes.tanulokszamaLocked);
            cheaterCountSlider.GetComponent<CsuszdaElemMrk>().Locker(mentes.puskazokszamaLocked);
     

            frontPanel.GetComponent<ValasztoBool>().Locker(mentes.frontPanelLocked);
            sidePanel.GetComponent<ValasztoBool>().Locker(mentes.sidePanelLocked);
            monitor.GetComponent<ValasztoBool>().Locker(mentes.monitorLocked);

            // mentes.playerPadid = 10;
            QuestionsNumber.GetComponent<CsuszdaElemMrk>().Locker(mentes.QuestionsNumberLocked);
            QuestionsNumberExam.GetComponent<CsuszdaElemMrk>().Locker(mentes.QuestionsNumberExamLocked);
            
            questionLength.GetComponent<CsuszdaElemMrk>().Locker(mentes.questionLengthLocked);
            ExamQuestionTime.GetComponent<CsuszdaElemMrk>().Locker(mentes.ExamQuestionTimeLocked);
            PrepareQuestionTime.GetComponent<CsuszdaElemMrk>().Locker(mentes.PrepareQuestionTimeLocked);
            subject.GetComponent<TMP_Dropdown>().interactable = !mentes.subjectLocked;
              //Tanar tulajdonsagok
            alertness.GetComponent<CsuszdaElemMrk>().Locker(mentes.alertnessLocked);
            frontBack.GetComponent<CsuszdaElemMrk>().Locker(mentes.frontBackLocked);
            walking.GetComponent<CsuszdaElemMrk>().Locker(mentes.walkingLocked);
            agressiveness.GetComponent<CsuszdaElemMrk>().Locker(mentes.agressivenessLocked);
            eyes.GetComponent<CsuszdaElemMrk>().Locker(mentes.eyesLocked);
            speed.GetComponent<CsuszdaElemMrk>().Locker(mentes.speedLocked);

            karma.GetComponent<CsuszdaElemMrk>().Locker(mentes.karmaLocked);

         
        
            
            
        }

     
    }
}