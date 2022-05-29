USE HOAChairmanAssistantDB;

Select Flats.FlatNumber, Owners.Surname, Owners.Name, Owners.Patronymic, PhoneNumbers.MobilePhone, Owners.CurrentDebt, Owners.OwnerStatusId
from Flats inner join Owners on Flats.FlatId = Owners.FlatId inner join PhoneNumbers on Owners.PhoneNumberId = PhoneNumbers.PhoneNumberId