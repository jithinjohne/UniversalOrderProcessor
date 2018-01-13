namespace OrderSource
{
    /// <summary>
    /// Something which can receive orders
    /// </summary>
    public interface IReceivable
    {
        /// <summary>
        /// Recieve
        /// </summary>
        void Receive();
    }
}