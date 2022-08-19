using OnionLibrary.DAL.Interfaces;
using OnionLibrary.Domain.Models;
using System;

public interface IShelfRepository: IBaseRepository<Shelf>
{
	//пока не буду делать методов для полок использую только общие базовые, так как потом будут методы по запросам через linq
}
