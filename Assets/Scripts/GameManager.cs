using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stats.OtherStats;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Event = Events.Event;
using Image = UnityEngine.UI.Image;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    private TaskCompletionSource<int> optionClick;
    [ SerializeField ] public StatsObject stats;
    [ SerializeField ] public StatsObject startingStats;
    [SerializeField] private List<Event> events;
    [SerializeField] private int round;
    [SerializeField] private TMP_Text eventText;
    [SerializeField] private TMP_Text eventDescription;
    [SerializeField] private TMP_Text eventStatChanges;
    [SerializeField] private Button button1;
    [SerializeField] private TMP_Text button1Text;
    [SerializeField] private Button button2;
    [SerializeField] private TMP_Text button2Text;
    [SerializeField] private List<Button> actionButtons;
    [SerializeField] private Image BackgroundImage;

    private void Start()
    {
        if (!stats.ifGameStarted)
        {
            StartGame();
        }
        stats.Age = stats.Age;
    }
    
    public void StartGame()
    {
        round = 0;
        stats.Age = startingStats.Age;
        stats.Gold = startingStats.Gold;
        stats.Year = startingStats.Year;
        stats.EndGame = startingStats.EndGame;
        stats.GoldIncome = startingStats.GoldIncome;
        stats.MaxPopularity = startingStats.MaxPopularity;
        stats.Popularity = startingStats.Popularity;
        stats.Achievements = startingStats.Achievements;
        stats.ActionPoints = startingStats.StartingActionPoints;
        stats.StartingActionPoints = startingStats.StartingActionPoints;
        stats.Achievements = new List<Achievement>();
        stats.Effects = new List<Effect>();
        StartRound();
        
    }
    private async void StartRound()
    {
        round += 1;
        stats.Age += 2;
        stats.Year += 2;
        print("Round starting new round! -> " + round);

        if (events.Where(x => x.whenHappensRound == round).ToList().Count == 0)
        {
            var randomEvent = UnityEngine.Random.Range(0, 
                events.Where(x=>x.whenHappensRound == 0)
                    .ToList().Count-1);
            print("Running random event! " + events.Where(x => x.whenHappensRound == 0).ToList()[randomEvent].eventDescription);
            await RunEvent(events.Where(x => x.whenHappensRound == 0).ToList()[randomEvent]);
            print("Ended random event!");
        }
        List<Event> currentEvents = events.Where(x => x.whenHappensRound == round).ToList();
        foreach (var e in events.Where(x => x.whenHappensRound == round))
        {
            print("Running event!");
            await RunEvent(e);
            print("Ended event!");
        }
        var newList = new List<Effect>();
        foreach(var e in stats.Effects)
        {
            print("Checking effects");
            var ifEffect = e.CheckIfTime(stats);
            if (ifEffect) newList.Add(e);
        }
        foreach (var e in newList)
        {
            stats.Effects.Remove(e);
        }
        stats.ActionPoints = stats.StartingActionPoints;
    }
    public void EndRound()
    {
        print("Round has ended!");
        StartRound();
        if (round == 30)
        {
            SceneManager.LoadScene("End");
        }
    }

 

    public void OptionChoose(int option)
    {
        this.optionClick.TrySetResult(option);
    }
    public async Task<bool> RunEvent(Event e)
     {
         print("Inside event " + e.eventDescription);
         foreach (var actionButton in actionButtons)
         {
             actionButton.enabled = false;
         }
         eventText.text = e.eventText;
         eventDescription.text = e.eventDescription;
         if (e.background != null)
         {
             BackgroundImage.sprite = e.background;
         }
         var option = 1;
         while (true)
         {
             if (e.IfOption())
             {
                 button1.gameObject.SetActive(true);
                 button2.gameObject.SetActive(true);
                 button1.enabled = true;
                 button2.enabled = true;
                 if (e.option1.costActionPoints > stats.ActionPoints || e.option1.costGold > stats.Gold)
                 {
                     button1.enabled = false;
                 }
                 if (e.option2.costActionPoints > stats.ActionPoints || e.option2.costGold > stats.Gold)
                 {
                     button2.enabled = false;
                 }
                 button1Text.text = e.option1.buttonText;
                 button2Text.text = e.option2.buttonText;
                 print("cos21");
                 print("Running option check");
                 optionClick = new TaskCompletionSource<int>();
                 print("cos23");
                 option = await optionClick.Task;
                 print("cos24");
                 button1.gameObject.SetActive(false);
                 button2.gameObject.SetActive(false);
                 print("cos25");
             }
             eventStatChanges.text = e.GetOption(option).eventStatChangesText;
             print("cos");
             if (e.UpdateStats(stats, round, events, option)) break;
             print("Cost to high!");
         }
         foreach (var actionButton in actionButtons)
         {
             actionButton.enabled = true;
         }

         var chosenOption = option == 1 ? e.option1 : e.option2;
         if (chosenOption.nazwaSceny.Length > 0)
         {
             SceneManager.LoadScene(chosenOption.nazwaSceny);
         }
         print("Returning event" + e.eventDescription);
         return true;
     }
    
    public bool RunBasicEvent(Event e, int option)
    {
        
        print("Running basic event");
        eventText.text = "";
        eventDescription.text = "";
        eventStatChanges.text = "";
        if (stats.ActionPoints == 0)
        {
            eventText.text = "Nie możesz wykonać tej akcji!";
            return false;
        }

        if (stats.Effects.Contains(restEvent.option1.Effects[0]))
        {
            eventText.text = "Już wypoczywałeś!";
            return false;
        }
        var ifUpdated = e.UpdateStats(stats, round, events, option);
        print(ifUpdated);
        if (ifUpdated)
        {
            eventText.text = e.eventText;
            eventDescription.text = e.eventDescription;
            eventStatChanges.text = e.option1.eventStatChangesText;
            return true;
        }
        eventText.text = "Nie możesz wykonać tej akcji!";
        return false;
    }

    //ROUND ACTIONS
    [SerializeField] private Event restEvent;
    
    public void Rest()
    {
        if (stats.Effects.Contains(restEvent.option1.Effects[0]))
        {
            eventText.text = "Już wypoczywałeś!";
            eventDescription.text = "";
            eventStatChanges.text = "";
            return;
        }
        int remainingPoints = stats.ActionPoints;
        restEvent.option1.Effects[0].startingActionPoints = remainingPoints / 2;
        var result = RunBasicEvent(restEvent, 1);
        if (result == true)
        {
            stats.ActionPoints = 0;
        }
    }

    [SerializeField] private Event WriteEvent;
    public void Write()
    {
        throw new NotImplementedException();
    }
    [SerializeField] private Event gambleEvent;
    public void Gamble()
    {
        int num = UnityEngine.Random.Range(1, 101);
        if (num > 75)
        {
            RunBasicEvent(gambleEvent, 1);
            return;
        }
        RunBasicEvent(gambleEvent, 2);
    }
    [SerializeField] private Event goToWorkEvent;
    public void GoToWork()
    {
        RunBasicEvent(goToWorkEvent, 1);
    }
    public void Test()
    {
        print("TESTING!");
        round += 1;
        stats.Age = stats.Age + 1;
        stats.Popularity = stats.Popularity + 15;
        stats.Gold = stats.Gold + 16;
        stats.Year = stats.Year + 156;
    }
}
