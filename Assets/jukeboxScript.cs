using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using jukebox;

public class jukeboxScript : MonoBehaviour
{
		public KMBombInfo Bomb;
		public KMSelectable button1;
		public KMSelectable button2;
		public KMSelectable button3;

		public Renderer button1Rend;
		public Renderer button2Rend;
		public Renderer button3Rend;

		public TextMesh lyric1Text;
		public TextMesh lyric2Text;
		public TextMesh lyric3Text;

		public Texture vinyl;
		public Texture vinylPass;

		public KMAudio Audio;
		string correctAudio;

		private List<string> lyricOptions = new List<string>();
		private List<string> randomLyrics = new List<string>();

    private List<string> chosenLyrics = new List<string>();

		static int moduleIdCounter = 1;
		int moduleId;
		private string TwitchHelpMessage = "Type '!{0} press 321' (1 = top; 2 = middle; 3 = bottom.)";

		private void Shuffle<T>(IList<T> list)
		{
		    int n = list.Count;
		    while (n > 0)
				{
		        n--;
		        int k = UnityEngine.Random.Range(0, n);
		        T value = list[k];
		        list[k] = list[n];
		        list[n] = value;
		    }
		}

		public KMSelectable[] ProcessTwitchCommand(string command)
		{
				if (command.Equals("press 123", StringComparison.InvariantCultureIgnoreCase))
				{
						return new KMSelectable[] { button1, button2, button3 };
				}
				else if (command.Equals("press 132", StringComparison.InvariantCultureIgnoreCase))
				{
					return new KMSelectable[] { button1, button3, button2 };
				}
				else if (command.Equals("press 213", StringComparison.InvariantCultureIgnoreCase))
				{
					return new KMSelectable[] { button2, button1, button3 };
				}
				else if (command.Equals("press 231", StringComparison.InvariantCultureIgnoreCase))
				{
					return new KMSelectable[] { button2, button3, button1 };
				}
				else if (command.Equals("press 312", StringComparison.InvariantCultureIgnoreCase))
				{
					return new KMSelectable[] { button3, button1, button2 };
				}
				else if (command.Equals("press 321", StringComparison.InvariantCultureIgnoreCase))
				{
					return new KMSelectable[] { button3, button2, button1 };
				}
				return null;
		}

		void Awake ()
		{
				moduleId = moduleIdCounter++;
				button1.OnInteract += delegate () { ButtonPress(randomLyrics[0], button1Rend); return false; };
				button2.OnInteract += delegate () { ButtonPress(randomLyrics[1], button2Rend); return false; };
				button3.OnInteract += delegate () { ButtonPress(randomLyrics[2], button3Rend); return false; };
		}

		void Start ()
		{
				//Pick the song to be used and compile the lyrics list
				lyricOptions.Clear();
				randomLyrics.Clear();
				button1Rend.material.mainTexture = vinyl;
				button2Rend.material.mainTexture = vinyl;
				button3Rend.material.mainTexture = vinyl;

				int songPick = UnityEngine.Random.Range (0, 25);

				if (songPick == 0)
				{
						whoWantsMethod();
						correctAudio = ("1.whoWants");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Who Wants to Live Forever?' by Queen.", moduleId);
				}
				if (songPick == 1)
				{
						takeAChanceMethod();
						correctAudio = ("2.takeAChance");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Take a Chance on Me' by ABBA.", moduleId);
				}
				if (songPick == 2)
				{
						takeMeToChurchMethod();
						correctAudio = ("3.takeMeToChurch");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Take Me to Church' by Hozier.", moduleId);
				}
				if (songPick == 3)
				{
						takeOnMeMethod();
						correctAudio = ("4.takeOnMe");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Take on Me' by a-Ha.", moduleId);
				}
				if (songPick == 4)
				{
						africaMethod();
						correctAudio = ("5.africa");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Africa' by Toto.", moduleId);
				}
				if (songPick == 5)
				{
						littleLessMethod();
						correctAudio = ("6.littleLess");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'A Little Less Conversation' by Elvis Presley vs. JXL.", moduleId);
				}
				if (songPick == 6)
				{
						floodMethod();
						correctAudio = ("7.flood");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'The Flood' by Take That.", moduleId);
				}
				if (songPick == 7)
				{
						smallThingsMethod();
						correctAudio = ("8.allTheSmall");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'All the Small Things' by Blink 182.", moduleId);
				}
				if (songPick == 8)
				{
						fridayMethod();
						correctAudio = ("9.friday");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Friday I'm in Love' by The Cure.", moduleId);
				}
				if (songPick == 9)
				{
						ymcaMethod();
						correctAudio = ("10.ymca");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'YMCA' by The Village People.", moduleId);
				}
				if (songPick == 10)
				{
						freeBirdMethod();
						correctAudio = ("11.freeBird");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Free Bird' by Lynyrd Skynyrd.", moduleId);
				}
				if (songPick == 11)
				{
						goodbyeMethod();
						correctAudio = ("12.goodbye");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Goodbye Mr A' by The Hosiers.", moduleId);
				}
				if (songPick == 12)
				{
						pureShoresMethod();
						correctAudio = ("13.pureShores");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Pure Shores' by All Saints.", moduleId);
				}
				if (songPick == 13)
				{
						skinMethod();
						correctAudio = ("14.skin");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Skin' by Rag'n'Bone Man.", moduleId);
				}
				if (songPick == 14)
				{
						ohMyGodMethod();
						correctAudio = ("15.ohMyGod");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Oh My God' by Kaiser Chiefs.", moduleId);
				}
				if (songPick == 15)
				{
						saySomethingMethod();
						correctAudio = ("16.saySomething");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Say Something' by A Great Big World.", moduleId);
				}
				if (songPick == 16)
				{
						youDontKnowMeMethod();
						correctAudio = ("17.youDontKnowMe");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'You Don't Know Me' by Michael Bublé.", moduleId);
				}
				if (songPick == 17)
				{
						helloMethod();
						correctAudio = ("18.hello");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Hello' by Adele.", moduleId);
				}
				if (songPick == 18)
				{
						healTheWorldMethod();
						correctAudio = ("19.healTheWorld");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Heal the World' by Michael Jackson.", moduleId);
				}
				if (songPick == 19)
				{
						upWhereWeBelongMethod();
						correctAudio = ("20.upWhereWeBelong");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Up Where We Belong' by Joe Cocker & Jennifer Warnes.", moduleId);
				}
				if (songPick == 20)
				{
						doYouHearMethod();
						correctAudio = ("21.doYouHear");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Do You Hear the People Sing?' from Les Misérables.", moduleId);
				}
				if (songPick == 21)
				{
						saveRockMethod();
						correctAudio = ("22.saveRock");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Save Rock'n'Roll' by Fall Out Boy (ft. Elton John).", moduleId);
				}
				if (songPick == 22)
				{
						perfectMethod();
						correctAudio = ("23.perfect");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Perfect' by Ed Sheeran.", moduleId);
				}
				if (songPick == 23)
				{
						makeYourOwnMethod();
						correctAudio = ("24.makeYourOwn");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'Make Your Own Kind of Music' by Mama Cass Elliot.", moduleId);
				}
				if (songPick == 24)
				{
						saveALifeMethod();
						correctAudio = ("25.saveALife");
						Debug.LogFormat("[The Jukebox #{0}] The chosen song is 'How to Save a Life' by The Fray.", moduleId);
				}

				//Decide the lyrics, randomise the order, render the buttons and debug
				while (lyricOptions.Count > 3)
				{
    				lyricRemoval();
				}
				randomLyrics.AddRange(lyricOptions);
				Shuffle(randomLyrics);

				lyric1Text.text = randomLyrics[0];
				lyric2Text.text = randomLyrics[1];
				lyric3Text.text = randomLyrics[2];
				Debug.LogFormat("[The Jukebox #{0}] The chosen lyrics are {1}, {2}, {3}.", moduleId, randomLyrics[0], randomLyrics[1], randomLyrics[2]);
				Debug.LogFormat("[The Jukebox #{0}] The correct order is {1}, {2}, {3}.", moduleId, lyricOptions[0], lyricOptions[1], lyricOptions[2]);
		}

		//Buttons
		void ButtonPress (string lyric, Renderer buttonRend)
		{
				if (chosenLyrics.Contains(lyric))
				{
						return;
				}
				GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
				GetComponent<KMSelectable>().AddInteractionPunch();
				Audio.PlaySoundAtTransform("recordScratch1", transform);

        chosenLyrics.Add(lyric);
        buttonRend.material.mainTexture = vinylPass;

        //If there aren't 3 choices yet, don't submit yet
        if (chosenLyrics.Count < 3)
        {
            return;
        }

        for (int lyricIndex = 0; lyricIndex < 3; ++lyricIndex)
        {
            if (chosenLyrics[lyricIndex] != lyricOptions[lyricIndex])
						{
            		//Then you've gone wrong
								GetComponent<KMBombModule>().HandleStrike();
								Debug.LogFormat("[The Jukebox #{0}] Strike! You pressed {1}, {2}, {3}.", moduleId, chosenLyrics[0], chosenLyrics[1], chosenLyrics[2]);
                chosenLyrics.Clear();
								Start();
            		return;
						}
        }
				//Audio.PlaySoundAtTransform(correctAudio, transform);
				Debug.LogFormat("[The Jukebox #{0}] You pressed {1}, {2}, {3}. Module disarmed.", moduleId, chosenLyrics[0], chosenLyrics[1], chosenLyrics[2]);
        GetComponent<KMBombModule>().HandlePass();
		}

		//Used to remove lyrics from the compiled list; runs until three remain
		string lyricRemoval()
		{
				var ix = UnityEngine.Random.Range(0, lyricOptions.Count);
				var result = lyricOptions[ix];
				lyricOptions.RemoveAt(ix);
				return result;
		}

		//Lyric lists
		void whoWantsMethod ()
		{
				lyricOptions.Add("Time");
				lyricOptions.Add("Place");
				lyricOptions.Add("What");
				lyricOptions.Add("Thing");
				lyricOptions.Add("Builds");
				lyricOptions.Add("Dreams");
				lyricOptions.Add("Slips");
				lyricOptions.Add("Away");
		}
		void takeAChanceMethod ()
		{
				lyricOptions.Add("Change");
				lyricOptions.Add("Mind");
				lyricOptions.Add("Honey");
				lyricOptions.Add("Still");
				lyricOptions.Add("Free");
				lyricOptions.Add("Take");
				lyricOptions.Add("Me");
		}
		void takeMeToChurchMethod ()
		{
				lyricOptions.Add("Lover's");
				lyricOptions.Add("Humour");
				lyricOptions.Add("Funeral");
				lyricOptions.Add("Knows");
				lyricOptions.Add("Everybody's");
				lyricOptions.Add("Should");
				lyricOptions.Add("Have");
				lyricOptions.Add("Sooner");
		}
		void takeOnMeMethod ()
		{
				lyricOptions.Add("We're");
				lyricOptions.Add("Talking");
				lyricOptions.Add("Away");
				lyricOptions.Add("Don't");
				lyricOptions.Add("Know");
				lyricOptions.Add("Anyway");
		}
		void africaMethod ()
		{
				lyricOptions.Add("Hear");
				lyricOptions.Add("Drums");
				lyricOptions.Add("Tonight");
				lyricOptions.Add("Hears");
				lyricOptions.Add("Quiet");
				lyricOptions.Add("Conversation");
		}
		void littleLessMethod ()
		{
				lyricOptions.Add("Less");
				lyricOptions.Add("Conversation");
				lyricOptions.Add("More");
				lyricOptions.Add("Action");
				lyricOptions.Add("Please");
				lyricOptions.Add("Aggravation");
				lyricOptions.Add("Satisfaction");
				lyricOptions.Add("Me");
		}
		void floodMethod ()
		{
				lyricOptions.Add("Standing");
				lyricOptions.Add("Edge");
				lyricOptions.Add("Forever");
				lyricOptions.Add("Start");
				lyricOptions.Add("Whatever");
				lyricOptions.Add("Shouting");
				lyricOptions.Add("Love");
				lyricOptions.Add("World");
		}
		void smallThingsMethod ()
		{
				lyricOptions.Add("All");
				lyricOptions.Add("Things");
				lyricOptions.Add("True");
				lyricOptions.Add("Care");
				lyricOptions.Add("Truth");
				lyricOptions.Add("Brings");
				lyricOptions.Add("Take");
				lyricOptions.Add("Ride");
				lyricOptions.Add("Trip");
		}
		void fridayMethod ()
		{
				lyricOptions.Add("Don't");
				lyricOptions.Add("Care");
				lyricOptions.Add("Monday's");
				lyricOptions.Add("Blue");
				lyricOptions.Add("Grey");
				lyricOptions.Add("Wednesday");
		}
		void ymcaMethod ()
		{
				lyricOptions.Add("There's");
				lyricOptions.Add("Need");
				lyricOptions.Add("Feel");
				lyricOptions.Add("Down");
				lyricOptions.Add("Yourself");
				lyricOptions.Add("Ground");
		}
		void freeBirdMethod ()
		{
				lyricOptions.Add("Leave");
				lyricOptions.Add("Tomorrow");
				lyricOptions.Add("Still");
				lyricOptions.Add("Remember");
				lyricOptions.Add("Travelling");
				lyricOptions.Add("Many");
				lyricOptions.Add("Places");
				lyricOptions.Add("See");
		}
		void goodbyeMethod ()
		{
				lyricOptions.Add("Hole");
				lyricOptions.Add("Logic");
				lyricOptions.Add("Know");
				lyricOptions.Add("Answers");
				lyricOptions.Add("Claim");
				lyricOptions.Add("Science");
				lyricOptions.Add("Magic");
				lyricOptions.Add("Buy");
		}
		void pureShoresMethod ()
		{
				lyricOptions.Add("Crossed");
				lyricOptions.Add("Deserts");
				lyricOptions.Add("Miles");
				lyricOptions.Add("Swam");
				lyricOptions.Add("Water");
				lyricOptions.Add("Searching");
				lyricOptions.Add("Piece");
				lyricOptions.Add("Something");
		}
		void skinMethod ()
		{
				lyricOptions.Add("Heard");
				lyricOptions.Add("Sound");
				lyricOptions.Add("Walls");
				lyricOptions.Add("Came");
				lyricOptions.Add("Down");
				lyricOptions.Add("Thinking");
				lyricOptions.Add("You");
		}
		void ohMyGodMethod ()
		{
				lyricOptions.Add("Time");
				lyricOptions.Add("Side");
				lyricOptions.Add("End");
				lyricOptions.Add("Beautiful");
				lyricOptions.Add("Thing");
				lyricOptions.Add("Spend");
		}
		void saySomethingMethod ()
		{
				lyricOptions.Add("Something");
				lyricOptions.Add("Giving");
				lyricOptions.Add("You");
				lyricOptions.Add("One");
				lyricOptions.Add("Want");
		}
		void youDontKnowMeMethod ()
		{
				lyricOptions.Add("Give");
				lyricOptions.Add("Hand");
				lyricOptions.Add("Then");
				lyricOptions.Add("Hello");
				lyricOptions.Add("Hardly");
				lyricOptions.Add("Speak");
				lyricOptions.Add("Heart");
		}
		void helloMethod ()
		{
				lyricOptions.Add("Hello");
				lyricOptions.Add("Me");
				lyricOptions.Add("Wondering");
				lyricOptions.Add("After");
				lyricOptions.Add("Years");
				lyricOptions.Add("Meet");
		}
		void healTheWorldMethod ()
		{
				lyricOptions.Add("Place");
				lyricOptions.Add("Heart");
				lyricOptions.Add("Know");
				lyricOptions.Add("Love");
				lyricOptions.Add("Could");
				lyricOptions.Add("Much");
				lyricOptions.Add("Brighter");
				lyricOptions.Add("Tomorrow");
		}
		void upWhereWeBelongMethod ()
		{
				lyricOptions.Add("Knows");
				lyricOptions.Add("Tomorrow");
				lyricOptions.Add("Brings");
				lyricOptions.Add("World");
				lyricOptions.Add("Few");
				lyricOptions.Add("Hearts");
				lyricOptions.Add("Survive");
		}
		void doYouHearMethod ()
		{
				lyricOptions.Add("Hear");
				lyricOptions.Add("People");
				lyricOptions.Add("Sing");
				lyricOptions.Add("Songs");
				lyricOptions.Add("Men");
				lyricOptions.Add("Music");
				lyricOptions.Add("Will");
				lyricOptions.Add("Again");
		}
		void saveRockMethod ()
		{
				lyricOptions.Add("Need");
				lyricOptions.Add("More");
				lyricOptions.Add("Dreams");
				lyricOptions.Add("Less");
				lyricOptions.Add("Life");
				lyricOptions.Add("Dark");
				lyricOptions.Add("Light");
		}
		void perfectMethod ()
		{
				lyricOptions.Add("Found");
				lyricOptions.Add("Love");
				lyricOptions.Add("Me");
				lyricOptions.Add("Darling");
				lyricOptions.Add("Dive");
				lyricOptions.Add("Right");
				lyricOptions.Add("Follow");
				lyricOptions.Add("Lead");
		}
		void makeYourOwnMethod ()
		{
				lyricOptions.Add("Nobody");
				lyricOptions.Add("Tell");
				lyricOptions.Add("There's");
				lyricOptions.Add("One");
				lyricOptions.Add("Song");
				lyricOptions.Add("Singing");
		}
		void saveALifeMethod ()
		{
				lyricOptions.Add("Step");
				lyricOptions.Add("One");
				lyricOptions.Add("Need");
				lyricOptions.Add("Talk");
				lyricOptions.Add("Walks");
				lyricOptions.Add("Sit");
				lyricOptions.Add("Down");
		}

}
