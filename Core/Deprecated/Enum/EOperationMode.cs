namespace Falcon.App.Core.Enum
{
    /// <summary>
    /// This enum will specify the Operation that needs to 
    /// be performed on the database level.
    /// </summary>
    public enum EOperationMode
    {
        /// <summary>
        /// Insert the information into the database
        /// </summary>
        Insert = 0,
        /// <summary>
        /// Update the information into the database
        /// </summary>
        Update = 1,
        /// <summary>
        /// Deactivate the information into the database
        /// </summary>
        DeActivate = 2,
        /// <summary>
        /// Delete the information into the database
        /// </summary>
        Delete = 3,
        /// <summary>
        /// Activate the information into the database
        /// </summary>
        Activate = 4
    }
}