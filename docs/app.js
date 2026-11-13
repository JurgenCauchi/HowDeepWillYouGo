const questions = [

    // LEVEL 1 - GREEN
    { Level: 1, Text: "What's your favourite childhood memory?" },
    { Level: 1, Text: "If you could travel anywhere tomorrow, where would you go?" },
    { Level: 1, Text: "What's something that always makes you laugh?" },
    { Level: 1, Text: "What's your idea of a perfect weekend?" },
    { Level: 1, Text: "What's the most spontaneous thing you've ever done?" },
    { Level: 1, Text: "If you could master any skill instantly, what would it be?" },
    { Level: 1, Text: "What's a small thing that instantly improves your mood?" },
    { Level: 1, Text: "What's the best compliment you've ever received?" },
    { Level: 1, Text: "What fictional world would you love to live in?" },
    { Level: 1, Text: "What's something you've always wanted to try?" },
    { Level: 1, Text: "What's your most unpopular harmless opinion?" },
    { Level: 1, Text: "What's a song that reminds you of a happy moment?" },
    { Level: 1, Text: "What's the funniest misunderstanding you've experienced?" },
    { Level: 1, Text: "If money weren't an issue, how would you spend your days?" },
    { Level: 1, Text: "What's something people are surprised to learn about you?" },

    // LEVEL 2 - ORANGE
    { Level: 2, Text: "What's something you wish people understood about you?" },
    { Level: 2, Text: "When was the last time you felt genuinely proud of yourself?" },
    { Level: 2, Text: "What's a friendship that changed your life?" },
    { Level: 2, Text: "What's a fear you've managed to overcome?" },
    { Level: 2, Text: "Have you ever pretended to be okay when you weren't?" },
    { Level: 2, Text: "What's something you find difficult to admit?" },
    { Level: 2, Text: "What's a mistake that taught you an important lesson?" },
    { Level: 2, Text: "When do you feel most like yourself?" },
    { Level: 2, Text: "What's something you're currently insecure about?" },
    { Level: 2, Text: "Have you ever lost touch with someone you still think about?" },
    { Level: 2, Text: "What's something you've changed your mind about recently?" },
    { Level: 2, Text: "What's a boundary you wish you'd established sooner?" },
    { Level: 2, Text: "What makes you feel genuinely appreciated?" },
    { Level: 2, Text: "What's a difficult conversation you've been avoiding?" },
    { Level: 2, Text: "What part of your personality do you rarely show others?" },

    // LEVEL 3 - RED
    { Level: 3, Text: "What's something you've never fully forgiven yourself for?" },
    { Level: 3, Text: "What's your deepest fear about the future?" },
    { Level: 3, Text: "When was the last time you felt completely alone?" },
    { Level: 3, Text: "What's something you wish you could tell your younger self?" },
    { Level: 3, Text: "Have you ever pushed someone away because you were afraid of getting hurt?" },
    { Level: 3, Text: "What's a truth about yourself that took years to accept?" },
    { Level: 3, Text: "What's the hardest goodbye you've ever experienced?" },
    { Level: 3, Text: "Have you ever stayed in a situation because you were afraid of change?" },
    { Level: 3, Text: "What do you think people misunderstand most about your emotional needs?" },
    { Level: 3, Text: "What's something you wish you had the courage to say to someone?" },
    { Level: 3, Text: "What's a painful experience that changed how you see the world?" },
    { Level: 3, Text: "What does being truly loved mean to you?" },
    { Level: 3, Text: "What's something you're still trying to heal from?" },
    { Level: 3, Text: "If you could ask one person a question and receive a completely honest answer, what would you ask?" },
    { Level: 3, Text: "What would you change about your life if you knew nobody would judge you?" }
];

function shuffleDeck() {
    return [1, 2, 3].flatMap(level => {
        const cards = questions.filter(q => q.Level === Level);

        for (let i = cards.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [cards[i], cards[j]] = [cards[j], cards[i]];
        }

        return cards;
    });
}


let deck = shuffleDeck();
let currentIndex = 0;

const levelTitle = document.getElementById("levelTitle");
const questionText = document.getElementById("questionText");
const nextButton = document.getElementById("nextButton");

function showCard() {
    const card = deck[currentIndex];

    levelTitle.textContent = `Level ${card.Level}`;
    levelTitle.className = `level-${card.Level}`;

    questionText.textContent = card.Text;

    if (currentIndex === deck.length - 1) {
        nextButton.textContent = "Restart Game →";
    } else if (card.Level !== deck[currentIndex + 1].Level) {
        nextButton.textContent = "Next Level →";
    } else {
        nextButton.textContent = "Next Card →";
    }
}

nextButton.addEventListener("click", () => {
    if (currentIndex === deck.length - 1) {
        deck = shuffleDeck();
        currentIndex = 0;
    } else {
        currentIndex++;
    }

    showCard();
});

showCard();


if ("serviceWorker" in navigator) {
    navigator.serviceWorker.register("./service-worker.js");
}