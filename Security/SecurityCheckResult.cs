using System;
namespace AeroGear.Mobile.Security
{
    public class SecurityCheckResult
    {
        /// <summary>
        /// The identifier of the check that produced this result.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The human readable name of the check that produced this result.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Whether the check has passed or not.
        /// </summary>
        public bool Passed { get; }

        public SecurityCheckResult(ISecurityCheck check, bool passed)
        {
            this.Id = check.GetId();
            this.Name = check.GetName();
            this.Passed = passed;
        }
    }
}
