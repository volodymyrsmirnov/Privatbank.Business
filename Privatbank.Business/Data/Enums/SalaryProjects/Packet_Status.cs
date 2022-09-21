using Privatbank.Business.Data.Models.SalaryProjects;

namespace Privatbank.Business.Data.Enums.SalaryProjects {
    /// <summary>
    /// salary project packet status, <see cref="Packet"/> and for sub-status <see cref="Packet_Sub_Status"/>
    /// </summary>
    public enum Packet_Status {
        /// <summary>
        /// created
        /// Пакет створено, і допускає редагування
        /// </summary>
        N,
        /// <summary>
        /// reviewed
        /// Пакет пройшов успішну перевірку, і його можна затвердити, або відізвати на редагування
        /// </summary>
        W,
        /// <summary>
        /// confirmed
        /// Пакет затверджено, і може бути підписаний або видалений
        /// </summary>
        S,
        /// <summary>
        /// signed by accountant
        /// Пакет очікує підпис директора
        /// </summary>
        SB,
        /// <summary>
        /// singed by director
        /// Пакет очікує підпис бухгалтера
        /// </summary>
        SD,

        /// <summary>
        /// fully reviewed
        /// Пакет отримав всі необхідні підписи і може бути відправлений в банк
        /// </summary>
        //S$,

        /// <summary>
        /// sent
        /// Пакет відправлено в банк на обробку
        /// </summary>
        X,
        /// <summary>
        /// In review
        /// Has Sub_status <see cref="Packet_Sub_Status"/>
        /// Пакет на перевірці (N->W, N->N)
        /// </summary>
        P,
        /// <summary>
        /// proccessed, for more details <see cref="Packet_Sub_Status"/>
        /// Has Sub_status 
        /// Пакет оброблено без помилок
        /// </summary>
        F,
        /// <summary>
        /// blocked
        /// Пакет забраковано
        /// </summary>
        R,
        /// <summary>
        /// deleted
        /// Пакет видалено
        /// </summary>
        D
    }
}
