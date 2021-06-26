namespace Babylon.Blazor.Chemical
{
    /// <summary>
    /// Class BondDescription.
    /// Atom connection description
    /// </summary>
    public class BondDescription
    {
        /// <summary>
        /// Enum BondType
        /// </summary>
        public enum BondType
        {
            /// <summary>
            /// The single bond
            /// </summary>
            Single = 0,

            /// <summary>
            /// The double bond
            /// </summary>
            Double,

            /// <summary>
            /// The triple bond
            /// </summary>
            Triple
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BondDescription"/> class.
        /// </summary>
        /// <param name="fromAtomIndex">Index of from atom.</param>
        /// <param name="toAtomIndex">Index of to atom.</param>
        /// <param name="bondType">Type of the bond.</param>
        public BondDescription(int fromAtomIndex, int toAtomIndex, BondType bondType)
        {
            FromAtomIndex = fromAtomIndex;
            ToAtomIndex = toAtomIndex;
            Type = bondType;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{FromAtomIndex} - {ToAtomIndex},{Type}";
        }

        /// <summary>
        /// Gets or sets the index of from atom.
        /// </summary>
        /// <value>The index of the 'from atom'.</value>
        public int FromAtomIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of to atom.
        /// </summary>
        /// <value>The index of the 'to atom'.</value>
        public int ToAtomIndex { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public BondType Type { get; set; }
    }
}
