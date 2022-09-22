﻿# Privat.Buisness changelog
## plan for 1.0.3
  add another enum in older models like 
   - `Transaction.Type`
   - `Transaction.DocumentType`
   - `Transaction.Status`
   - `Transaction.Real`

## 1.0.2 - salary groups, api 3-0-0
  added support for client with token only

  added salary groups:
  - get salary groups `GetGroupsAsync()`
  - get salary groups recipients `GetRecipientsAsync(GroupType type)`
  - get packets `GetPacketsAsync(DateTime from, DateTime to)`
  - get packet elements `GetPacketEntriesAsync(Packet packet)`

  salary groups use enums
## 1.0.2 - transactions
  functionality for transactions statements and balances