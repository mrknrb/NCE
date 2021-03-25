using Scenes.Game.Scripts.Structs;

namespace Scenes.Menu.MenuElemek.AcademyMenu
{
    abstract public class KuldetesMentesek
    {
        static public Mentes MentesBetoltes(string mentesNev)
        {
            var m = new Mentes();
            if (mentesNev == "1")
            {
                m.sor = 5;
                m.oszlop = 4;
                m.egyhelykihagy = false;
                m.randomulesrend = true;
                m.duplaPad = false;
                m.tanulokszama = 10;
                m.puskazokszama = 2;
                m.playerPadid = 5;


                m.frontPanel = true;
                m.sidePanel = true;
                m.monitor = true;

                m.QuestionsNumber = 20;
                m.QuestionsNumberExam = 10;
                m.questionLength = 4;
                m.questionTime = 30;
                m.subject = 2;

                m.alertness = 3;
                m.frontBack = 2;
                m.walking = 1;
                m.agressiveness = 4;
                m.eyes = 3;
                m.speed = 1;
                
                m.karma = 1;
                
                m.prepareTimeLimit = 10;


                //  locked
                m.sorLocked = true;
                m.oszlopLocked = false;
                m.egyhelykihagyLocked = true;
                m.randomulesrendLocked = true;
                m.duplaPadLocked = true;
                m.tanulokszamaLocked = true;
                m.puskazokszamaLocked = true;
                m.playerPadidLocked = true;

//asztal
                m.frontPanelLocked = true;
                m.sidePanelLocked = false;
                m.monitorLocked = true;
//exam
                m.QuestionsNumberLocked = true;
                m.QuestionsNumberExamLocked = true;
                m.questionLengthLocked = true;
                m.questionTimeLocked = false;
                m.subjectLocked = true;
                m.electronicDevicesLocked = false;
                m.calculatorLocked = true;
                m.secondChanceLocked = true;
                //
                m.alertnessLocked = true;
                m.frontBackLocked = true;
                m.walkingLocked = false;
                m.agressivenessLocked = true;
                m.eyesLocked = true;
                m.speedLocked = true;
                m.karmaLocked = true;
                //ng strategy
                m.prepareTimeLimitLocked = true;
            }


            return m;
        }
    }
}