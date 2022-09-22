namespace Privatbank.Business.Data.Enums.SalaryProjects {
    /// <summary>
    /// salary system, depending on it changes packet elements list api endpoint
    /// </summary>
    public enum SalarySystem {
        /// <summary>
        /// MASSPAYMENTS
        /// блок масових виплат, група MASSPAYMENTS
        /// </summary>
        reqpay,
        /// <summary>
        ///  зарплатний блок, група SALARY/STUDENT
        /// </summary>
        maspay,
    }
}
