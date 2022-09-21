# Privat.Buisness changelog
## plan for 1.2.1
  add another enum in older models like 
   - `Transaction.Type`
   - `Transaction.DocumentType`
   - `Transaction.Status`
   - `Transaction.Real`
## 1.2 - salary groups
  added salary groups:
  - get salary groups `GetGroupsAsync()`
  - get packets `GetPacketsAsync(DateTime from, DateTime to)`
  - get packet elements `GetPacketEntriesAsync(Packet packet)`

  salary groups use enums
## 1.1 - transactions
  functionality for transactions statements and balances