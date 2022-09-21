namespace Privatbank.Business.Data.Enums.SalaryProjects {
    /// <summary>
    /// sub status of a slary project pocket status, <see cref="Packet_Status"/>
    /// </summary>
    public enum Packet_Sub_Status {
        /// <summary>
        /// packet in review
        /// Пакет на перевірці (N->W, N->N)
        /// </summary>
        V,
        /// <summary>
        /// packet processing data
        /// Пакет обробляє імпорт сирих файлів (N->N)
        /// </summary>
        I,
        /// <summary>
        /// proccessed with no issues
        /// Пакет оброблено без помилок
        /// </summary>
        F,
        /// <summary>
        /// proccessed with issues
        /// Пакет оброблено з помилками
        /// </summary>
        R,
    }
}
