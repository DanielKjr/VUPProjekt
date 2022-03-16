using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace VUPProjekt
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Graph<string> graph = new Graph<string>();


        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            CreateNodes();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void CreateNodes()
        {
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

            graph.AddEdge("Skagen", "frederikshavn");
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
