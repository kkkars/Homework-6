namespace homework6.Task3
{
    public class Result
    {
        public int Successful { get; set; }
        public int Failed { get; set; }

        public Result(int successful, int failed)
        {
            Successful = successful;
            Failed = failed;
        }
    }
}
