using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Event = Events.Event;
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

    private void OnEnable()
    {
        StartGame();
    }
    
    public void StartGame()
    {
        round = 0;
        stats.Age = startingStats.Age;
        stats.Gold = startingStats.Gold;
        stats.Year = startingStats.Year;
        stats.Popularity = startingStats.Popularity;
        stats.Achievements = startingStats.Achievements;
        stats.ActionPoints = startingStats.StartingActionPoints;
        stats.StartingActionPoints = startingStats.StartingActionPoints;
        stats.Achievements = startingStats.Achievements;
        stats.Effects = startingStats.Effects;
        StartRound();
        
    }
    public void StartRound()
    {
        eventStatChanges.text = "";
        round += 1;
        stats.Age += 1;
        stats.Year += 1;
        stats.ActionPoints = startingStats.StartingActionPoints;
        print("Round starting new round! -> " + round);
        List<Event> currentEvents = events.Where(x => x.whenHappensRound == round).ToList();
        foreach (var e in events.Where(x => x.whenHappensRound == round))
        {
            print("Running event!");
            RunEvent(e).Wait();
            print("Ended event!");
        }

        var randomEvent = new Random().Next() % events.Where(x => x.whenHappensRound == 0).ToList().Count-1;
        print("Running random event!");
        RunEvent(events.Where(x => x.whenHappensRound == 0).ToList()[randomEvent]).Wait();
        print("Ended random event!");
        foreach(var e in stats.Effects)
        {
            e.CheckIfTime(stats);
        }
    }
    public void EndRound()
    {
        print("Round has ended!");
        StartRound();
    }

    public void OptionChoose(int option)
    {
        this.optionClick.TrySetResult(option);
    }

    //Events
    public async Task<bool> RunEvent(Event e)
    {
        print("Running event");
        foreach (var actionButton in actionButtons)
        {
            actionButton.enabled = false;
        }
        eventText.text = e.eventText;
        eventDescription.text = e.eventDescription;
        while (true)
        {
            int option = 1;
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
                print("Running option check");
                optionClick = new TaskCompletionSource<int>();
                option = await optionClick.Task;
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
            }
            eventStatChanges.text = e.GetOption(option).eventStatChangesText;

            if (!e.UpdateStats(stats, round, events, option)) continue;
            print("Cost to high!");
            break;
        }
        foreach (var actionButton in actionButtons)
        {
            actionButton.enabled = true;
        }

        return true;
    }
    
    public void RunBasicEvent(Event e)
    {
        print("Running basic event");
        eventText.text = "";
        eventDescription.text = "";
        eventStatChanges.text = "";
        var ifUpdated = e.UpdateStats(stats, round, events, 1);
        
        if (ifUpdated)
        {
            eventText.text = e.eventText;
            eventDescription.text = e.eventDescription;
            eventStatChanges.text = e.option1.eventStatChangesText;
            return;
        }
        eventText.text = "ZA MAŁO PUNKTÓW AKCJI!";
    }

    //ROUND ACTIONS
    [SerializeField] private Event restEvent;
    
    public void Rest()
    {
        int remainingPoints = stats.ActionPoints;
        stats.ActionPoints = 0;
        restEvent.option1.ActionPoints = remainingPoints / 2;
        stats.Effects.Add(restEvent.option1.Effects[0]);
    }

    [SerializeField] private Event WriteEvent;
    public void Write()
    {
        throw new NotImplementedException();
    }
    [SerializeField] private Event gambleWinEvent;
    [SerializeField] private Event gambleLoseEvent;
    public void Gamble()
    {
        System.Random rnd = new System.Random();
        int num = rnd.Next() % 100;
        if (num > 75)
        {
            RunBasicEvent(gambleWinEvent);
            return;
        }
        RunBasicEvent(gambleLoseEvent);
    }
    [SerializeField] private Event goToWorkEvent;
    public void GoToWork()
    {
        RunBasicEvent(goToWorkEvent);
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
