using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace VUPProjekt
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D danishMap;
        public Graph<string> graph;
        public List<City> cities = new List<City>();

       


        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
           
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1050;
            _graphics.ApplyChanges();

            CreateNodes();

         
            cities.Add(new City(new Vector2(500, 500), "Randers"));
            cities.Add(new City(new Vector2(500, 600), "Aalborg"));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            danishMap = Content.Load<Texture2D>("Danmarks Kort");
           

            foreach (City c in cities)
            {
                c.LoadContent(Content);
            }

       
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

       
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            _spriteBatch.Draw(danishMap, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);

            foreach (City c in cities)
            {
                c.Draw(_spriteBatch);
                
            
            }
            

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void CreateNodes()
        {
            graph = new Graph<string>();
            graph.AddNode("Skagen");
            graph.AddNode("Frederikshavn");
            graph.AddNode("Aalborg");
            graph.AddNode("Holsterbro");
            graph.AddNode("Viborg");
            graph.AddNode("Randers");
            graph.AddNode("Grenå");
            graph.AddNode("Herning");
            graph.AddNode("Århus");
            graph.AddNode("Billund");
            graph.AddNode("Vejle");
            graph.AddNode("Esbjerg");
            graph.AddNode("Kolding");
            graph.AddNode("Odense");

            graph.AddEdge("Skagen", "Frederikshavn");
            graph.AddEdge("Skagen", "Aalborg");

            graph.AddEdge("Frederikshavn", "Aalborg");

            graph.AddEdge("Aalborg", "Viborg");
            graph.AddEdge("Aalborg", "Randers");

            graph.AddEdge("Holsterbro", "Viborg");
            graph.AddEdge("Holsterbro", "Herning");
            graph.AddEdge("Holsterbro", "Esbjerg");

            graph.AddEdge("Viborg", "Herning");
            graph.AddEdge("Viborg", "Randers");

            graph.AddEdge("Randers", "Grenå");
            graph.AddEdge("Randers", "Århus");

            graph.AddEdge("Grenå", "Århus");

            graph.AddEdge("Herning", "Århus");
            graph.AddEdge("Herning", "Billund");

            graph.AddEdge("Århus", "Vejle");

            graph.AddEdge("Billund", "Vejle");
            graph.AddEdge("Billund", "Esbjerg");

            graph.AddEdge("Vejle", "Kolding");

            graph.AddEdge("Esbjerg", "Kolding");

            graph.AddEdge("Kolding", "Odense");
        }
    }
}
