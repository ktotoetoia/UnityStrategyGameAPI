namespace TDS
{
    public class DynamicFactory<T> : IFactory<T>
    {
        public System.Func<T> Factory {get; set;}
        
        public DynamicFactory(System.Func<T> factory)
        {
            Factory = factory;
        }
        
        public T Create()
        {
            return Factory();
        }
    }

    public class DynamicFactory<T, Param1> : IFactory<T, Param1>
    {        
        public System.Func<Param1,T> Factory {get; set;}
        
        public DynamicFactory(System.Func<Param1,T> factory)
        {
            Factory = factory;
        }
        
        public T Create(Param1 param1)
        {
            return Factory(param1);
        }
    }
    
    public class DynamicFactory<T, Param1, Param2> : IFactory<T, Param1, Param2>
    {        
        public System.Func<Param1,Param2, T> Factory {get; set;}
        
        public DynamicFactory(System.Func<Param1,Param2,T> factory)
        {
            Factory = factory;
        }
        
        public T Create(Param1 param1,Param2 param2)
        {
            return Factory(param1,param2);
        }
    }
}