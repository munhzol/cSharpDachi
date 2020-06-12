using System;

namespace DojoDachi.Models
{
    public class Dachi
    {
        public int Happiness{get;set;}
        public int Fullness{get;set;}
        public int Energy{get;set;}
        public int Meals{get;set;}
        private Random rand = new Random();
        public string Status {get;set;}

        public string Img {get;set;}

        public void Feed() {
            // Feeding your Dojodachi costs 1 meal and gains a random 
            // amount of fullness between 5 and 10 (you cannot feed your 
            // Dojodachi if you do not have meals)
            if(Meals>0){
                Meals--;
                int rnd = rand.Next(5,10);
                if(!IDontLikeIt()){
                    Fullness+=rnd;
                    Status = $"Fullness gained by {rnd} ";
                    Img = "feed";
                } else {
                    Status = $"No Fullness gained because Dachi doesn't like the meal, costs 5 energy";
                    Img = "nofeed";
                }
            } else {
                Status = $"You have no meal! ";
            }
            Won(); Lose();
        }
    
        public void Play() {
            //Playing with your Dojodachi costs 5 energy and gains a random amount of happiness between 5 and 10
            Energy-=5;
            int rnd = rand.Next(5,10);
            if(!IDontLikeIt()){
                Happiness+=rnd;
                Status = $"Happiness gained by {rnd}, costs 5 energy";
                Img = "play";
            }   else {
                Status = $"No Happiness gained because Dachi doesn't like the game, costs 5 energy";
                Img = "noplay";
            }
            Won(); Lose();
        }

        bool IDontLikeIt() {
            // Every time you play with or feed your dojodachi there should 
            // be a 25% chance that it won't like it. Energy or meals will 
            // still decrease, but happiness and fullness won't change.
            int rnd = rand.Next(0,100);
            return rnd<25;
        }

        public void Work() {
            //Working costs 5 energy and earns between 1 and 3 meals
            Energy-=5;
            int rnd = rand.Next(1,3);
            Meals+=rnd;
            Status = $"Meals gained by {rnd}, costs 5 energy";
            Img = "work";
            Won(); Lose();
        }

        public void Sleep() {
            //Sleeping earns 15 energy and decreases fullness and happiness each by 5
            Energy+=15;
            int rnd = rand.Next(1,3);
            Fullness-=5;
            Happiness-=5;
            Img = "sleep";
            Status = $"Energy gained by {15}, costs 5 Fullness, 5 Happiness";

            Won(); Lose();
        }

        public bool Won() {
            if(Energy>100 && Fullness>100 && Happiness>100){
                Img = "won";
                Status = $"You win!";
                return true;
            }
            return false;
        }

        public bool Lose() {
            if(Fullness<1 || Happiness<1){
                Img = "lose";
                Status = $"You Lost!";
                return true;
            }
            return false;
        }

        public void Reset() {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            Status = "Let's play! Play! Play! Play!!";
            Img ="start";        
        }

        public Dachi() {
            Reset();
        }

    }
}