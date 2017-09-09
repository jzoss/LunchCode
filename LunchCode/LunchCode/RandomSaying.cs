using System;
using System.Collections.Generic;
using System.Text;

namespace LunchCode
{


    public static class RandomSaying
    {
        private static Random random = new Random();
        private static List<string> FullCompliments = new List<string>{
            "You are more adorable than a baby panda riding a sneezing piglet.",
            "You're classier than Sir Patrick Stewart playing a grand piano on a yacht in Monaco.",
            "Your hair is sleek and glossy like the mane of a mighty stallion.",
            "You're the hero Gotham needs.",
            "Every time you smile, a kitten is born.",
            "You are more adorable than a baby panda riding a sneezing piglet.",
            "Your smile is contagious.",
            "You are cooler than Batman",
            "You've got all the right moves!",
            "On a scale from 1 to 10, you're an 11."

         };

        private static List<string> Animals = new List<string>{
            "dog",
            "cat",
            "fish",
            "ox",
            "bear",
            "Pokemon",
            "Arctic hare",
            "Bat-eared fox",
            "Cheetah",
            "Chimpanzee",
            "Fairy penguin",
            "Jungle cat",
            "Pampa gray fox",
            "Platypus",
            "Blue Shark",
            "Warthog",
            "Yellow mongoose",
            "Aardvark",
            "Barn Owl",
            "Caterpillar",
            "Darwin's Frog",
            "Dolphin",
            "Unicorn",
            "Bearded Collie",
            "Oyster",
            "Millipede",
            "Otter",
            "Woolly Mammoth",
            "Wolverine",
            "Wombat",
            "Zebra",
            "Quail",
            "Skunk",
            "Shrimp",
            "Scallop",
            "Opossum",
            "Newt",
            "Llama",
            "Narwhal",
            "Gila monster"



         };

        private static string[] Compliments = {
            "smart",
            "strong",
            "cool",
            "fashionable",
            "stylish",
            "excellent",
            "nifty",
            "dandy",
            "boss",
            "marvelous",
            "majestic",
            "awesome",
            "briliant",
            "amazing",
            "fantastic",
            "adorable",
            "clever",
            "creative",
            "Breathtaking",
            "Bold",
            "Unique",
            "Spunky",
            "Charming",
            "Sparky",

        };

        private static string[] Farewells = { "ADIOS!", "BYE!", "BYE-BYE!", "FAREWELL!", "GOODBYE!" };


        public static string YouAreCompliment()
        {
            var animal = Animals[random.Next(Animals.Count)];
            var connectingWord = "a";
            if(StartsWithVowel(animal))
            {
                connectingWord = "an";
            }
            return $"You are {Compliments[random.Next(Compliments.Length)]} like {connectingWord} {animal}";
        }

        private static bool StartsWithVowel(string s)
        {
            char start = s[0];
            return "aeiou".IndexOf(start.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

    }
}
