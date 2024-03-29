namespace flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            game game = new game();
            game.addparticles("red", 10);
            game.addparticles("red", 20);
            game.display();
        }
    }
    class particle
    {
        public string color { get; set; }

        public particle(string _color)
        {
            color = _color;
        }

        public void display(int speed)
        {
            Console.WriteLine("Element: " + color + " ,speed: " + speed);
        }
    }

    class movingparticles
    {
        particle partical;
        public int speed { get; set; } 
        public movingparticles(string _color,int _speed)
        {
            partical = factory.getpartical(_color);
            speed = _speed;
        }

        public void display()
        {
          partical.display(speed);
           
        }
    }
    class factory
    {
        static Dictionary<string, particle> particles = 
            new Dictionary<string, particle>();
        public static particle getpartical(string c)
        {
            if (particles.ContainsKey(c))
            {
                return particles[c];
            }
            else
            {
                return particles[c] = new particle(c);
            }

        }
    }

    class game
    {
        List<movingparticles> movingparticles = new List<movingparticles>();
        public void addparticles(string color,int speed)
        {
            movingparticles.Add(new movingparticles(color, speed));
        }
        public void display()
        {
            foreach(var item in movingparticles)
            {
                item.display();
            }
        }
    }
}

