using System.ComponentModel.DataAnnotations;

namespace ComTechNetCoreApp.Models.Enums
{
	public enum EFaculty
	{
		[Display(Name = "Факультет авиационных двигателей, энергетики и транспорта")]
		AircraftEngineAndTransportFaculty,

		[Display(Name = "Факультет авионики, энергетики и инфокоммуникаций")]
		EnergyAndInfoCommunicationFaculty,

		[Display(Name = "Факультет информатики и робототехники")]
		СomputerScienceAndRoboticsFaculty,

		[Display(Name = "Факультет защиты в чрезвычайных ситуациях")]
		ProtectionFromEmergencies
	}
}
