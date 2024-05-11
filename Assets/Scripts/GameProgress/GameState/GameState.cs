namespace GameProgress
{
    public abstract class GameState
    {
        protected GameContext _gameContext;
        
        public void Init(GameContext context)
        {
            _gameContext = context;
        }

        public abstract StateType GetStateType();

        public abstract void EnterState();
        
        public abstract void Update();

    }
}