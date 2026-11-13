using Microsoft.AspNetCore.Mvc;
using Deep_Cards.Model;

namespace Deep_Cards.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Card> Cards = new()
{
    // LEVEL 1 - GREEN
    new Card { Level = 1, Text = "What's your favourite childhood memory?" },
    new Card { Level = 1, Text = "If you could travel anywhere tomorrow, where would you go?" },
    new Card { Level = 1, Text = "What's something that always makes you laugh?" },
    new Card { Level = 1, Text = "What's your idea of a perfect weekend?" },
    new Card { Level = 1, Text = "What's the most spontaneous thing you've ever done?" },
    new Card { Level = 1, Text = "If you could master any skill instantly, what would it be?" },
    new Card { Level = 1, Text = "What's a small thing that instantly improves your mood?" },
    new Card { Level = 1, Text = "What's the best compliment you've ever received?" },
    new Card { Level = 1, Text = "What fictional world would you love to live in?" },
    new Card { Level = 1, Text = "What's something you've always wanted to try?" },
    new Card { Level = 1, Text = "What's your most unpopular harmless opinion?" },
    new Card { Level = 1, Text = "What's a song that reminds you of a happy moment?" },
    new Card { Level = 1, Text = "What's the funniest misunderstanding you've experienced?" },
    new Card { Level = 1, Text = "If money weren't an issue, how would you spend your days?" },
    new Card { Level = 1, Text = "What's something people are surprised to learn about you?" },

    // LEVEL 2 - ORANGE
    new Card { Level = 2, Text = "What's something you wish people understood about you?" },
    new Card { Level = 2, Text = "When was the last time you felt genuinely proud of yourself?" },
    new Card { Level = 2, Text = "What's a friendship that changed your life?" },
    new Card { Level = 2, Text = "What's a fear you've managed to overcome?" },
    new Card { Level = 2, Text = "Have you ever pretended to be okay when you weren't?" },
    new Card { Level = 2, Text = "What's something you find difficult to admit?" },
    new Card { Level = 2, Text = "What's a mistake that taught you an important lesson?" },
    new Card { Level = 2, Text = "When do you feel most like yourself?" },
    new Card { Level = 2, Text = "What's something you're currently insecure about?" },
    new Card { Level = 2, Text = "Have you ever lost touch with someone you still think about?" },
    new Card { Level = 2, Text = "What's something you've changed your mind about recently?" },
    new Card { Level = 2, Text = "What's a boundary you wish you'd established sooner?" },
    new Card { Level = 2, Text = "What makes you feel genuinely appreciated?" },
    new Card { Level = 2, Text = "What's a difficult conversation you've been avoiding?" },
    new Card { Level = 2, Text = "What part of your personality do you rarely show others?" },

    // LEVEL 3 - RED
    new Card { Level = 3, Text = "What's something you've never fully forgiven yourself for?" },
    new Card { Level = 3, Text = "What's your deepest fear about the future?" },
    new Card { Level = 3, Text = "When was the last time you felt completely alone?" },
    new Card { Level = 3, Text = "What's something you wish you could tell your younger self?" },
    new Card { Level = 3, Text = "Have you ever pushed someone away because you were afraid of getting hurt?" },
    new Card { Level = 3, Text = "What's a truth about yourself that took years to accept?" },
    new Card { Level = 3, Text = "What's the hardest goodbye you've ever experienced?" },
    new Card { Level = 3, Text = "Have you ever stayed in a situation because you were afraid of change?" },
    new Card { Level = 3, Text = "What do you think people misunderstand most about your emotional needs?" },
    new Card { Level = 3, Text = "What's something you wish you had the courage to say to someone?" },
    new Card { Level = 3, Text = "What's a painful experience that changed how you see the world?" },
    new Card { Level = 3, Text = "What does being truly loved mean to you?" },
    new Card { Level = 3, Text = "What's something you're still trying to heal from?" },
    new Card { Level = 3, Text = "If you could ask one person a question and receive a completely honest answer, what would you ask?" },
    new Card { Level = 3, Text = "What would you change about your life if you knew nobody would judge you?" }
};

        public IActionResult Index(int id = 0)
        {
            // Generate a shuffled deck when starting
            if (id == 0 || HttpContext.Session.GetString("Deck") == null)
            {
                var shuffledCards = Cards
                    .GroupBy(c => c.Level)
                    .OrderBy(g => g.Key)
                    .SelectMany(g => g.OrderBy(c => Random.Shared.Next()))
                    .ToList();

                HttpContext.Session.SetString(
                    "Deck",
                    System.Text.Json.JsonSerializer.Serialize(shuffledCards)
                );
            }

            var deck = System.Text.Json.JsonSerializer.Deserialize<List<Card>>(
                HttpContext.Session.GetString("Deck")!
            )!;

            if (id < 0 || id >= deck.Count)
                id = 0;

            ViewBag.NextId = (id + 1) % deck.Count;

            ViewBag.IsLastCardInLevel =
                id == deck.Count - 1 ||
                deck[id].Level != deck[id + 1].Level;

            return View(deck[id]);
        }
    }
}