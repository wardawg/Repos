namespace ReposDomain.Filters
{
        public class ClientConstBase
        {
    
            public int Value { get; set; }

            public const int CatNCatTypeDDLFilter = 1;
            public const int CatNCatTypeDDLRestFilter = 2;

            public ClientConstBase(int value)
            {
                Value = value;
            }

            public ClientConstBase(){
            }

            public static implicit operator int(ClientConstBase cType)
            {
                return cType.Value;
            }

            public static implicit operator ClientConstBase(int value)
            {
                return new ClientConstBase(value);
            }
            
            public T GetFilter<T>(object c) 
                    where T : struct
            {
                return (T)System.Enum.Parse(typeof(T), c.ToString(), false);
            }

        }
}


