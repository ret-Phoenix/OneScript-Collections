#Использовать asserts
#Использовать Collections

Функция ПолучитьСписокТестов(Тестирование) Экспорт
	
	СписокТестов = Новый Массив;
	
	СписокТестов.Добавить("Тест_Должен_КонструкторБезПараметров");
	СписокТестов.Добавить("Тест_Должен_КонструкторПараметрМассив");
	СписокТестов.Добавить("Тест_Должен_КонструкторПараметрЧисло");
	
	СписокТестов.Добавить("Тест_Должен_ВернутьКоличество0");
	СписокТестов.Добавить("Тест_Должен_ВернутьКоличество1");
	СписокТестов.Добавить("Тест_Должен_Добавить");
	
	СписокТестов.Добавить("Тест_Должен_Очистить");
	СписокТестов.Добавить("Тест_Должен_ВзятьИзОчереди");
	СписокТестов.Добавить("Тест_Должен_ВернутьСодержит");
	СписокТестов.Добавить("Тест_Должен_ВернутьНеСодержит");
	
	СписокТестов.Добавить("Тест_Должен_ПолучитьХешКод");
	
	СписокТестов.Добавить("Тест_Должен_ВернутьПик");
	СписокТестов.Добавить("Тест_Должен_ВернутьПикПроверкаОшибки");
	
	СписокТестов.Добавить("Тест_Должен_ВМассив");
	СписокТестов.Добавить("Тест_Должен_Обрезать");

	СписокТестов.Добавить("Тест_Должен_Перебрать");
	
	// СписокТестов.Добавить("Тест_Должен_Скопировать");
	// СписокТестов.Добавить("Тест_Должен_ВернутьРавен");
	// СписокТестов.Добавить("Тест_Должен_ВернутьНеРавен");
		
	Возврат СписокТестов;
	
КонецФункции


Процедура Тест_Должен_КонструкторБезПараметров() Экспорт
	Очередь = Новый Очередь();
	Ожидаем.Что(Строка(Очередь)).Равно("Очередь");
КонецПроцедуры

Процедура Тест_Должен_КонструкторПараметрМассив() Экспорт
	
	Данные = Новый Массив;
	Данные.Добавить(1);
	
	Очередь = Новый Очередь(Данные);
	Ожидаем.Что(Строка(Очередь)).Равно("Очередь");
КонецПроцедуры

Процедура Тест_Должен_КонструкторПараметрЧисло() Экспорт
	Очередь = Новый Очередь(3);
	Ожидаем.Что(Строка(Очередь)).Равно("Очередь");
КонецПроцедуры


Процедура Тест_Должен_ВернутьКоличество0() Экспорт
	Очередь = Новый Очередь();
	Ожидаем.Что(Очередь.Количество()).Равно(0);
КонецПроцедуры

Процедура Тест_Должен_ВернутьКоличество1() Экспорт
	Очередь = Новый Очередь();
	Очередь.Добавить("данные");
	Ожидаем.Что(Очередь.Количество()).Равно(1);
КонецПроцедуры


Процедура Тест_Должен_Добавить() Экспорт
	Очередь = Новый Очередь();
	Очередь.Добавить("данные");
	Ожидаем.Что(Очередь.Количество()).Равно(1);
КонецПроцедуры

Процедура Тест_Должен_Очистить() Экспорт
	Очередь = Новый Очередь();
	Очередь.Добавить("данные");
	Очередь.Очистить();
	Ожидаем.Что(Очередь.Количество()).Равно(0);
КонецПроцедуры


Процедура Тест_Должен_ВзятьИзОчереди() Экспорт
	Очередь = Новый Очередь();
	Очередь.Добавить("1");
	Очередь.Добавить("2");
	Очередь.Добавить("3");

	ПолученноеЗначение = Очередь.ВзятьИзОчереди();
	Ожидаем.Что(ПолученноеЗначение).Равно("1");
	
	ПолученноеЗначение = Очередь.ВзятьИзОчереди();
	Ожидаем.Что(ПолученноеЗначение).Равно("2");

	Ожидаем.Что(Очередь.Количество()).Равно(1);
КонецПроцедуры


Процедура Тест_Должен_ВернутьСодержит() Экспорт
	Очередь = Новый Очередь();
	Очередь.Добавить("1");
	Очередь.Добавить("2");
	Очередь.Добавить("3");
	Ожидаем.Что(Очередь.Содержит("1")).Равно(Истина);
КонецПроцедуры


Процедура Тест_Должен_ВернутьНеСодержит() Экспорт
	Очередь = Новый Очередь();
	Очередь.Добавить("1");
	Очередь.Добавить("2");
	Очередь.Добавить("3");
	Ожидаем.Что(Очередь.Содержит("4")).Равно(Ложь);
КонецПроцедуры

Процедура Тест_Должен_Скопировать() Экспорт
	Приемник = Новый Массив;
	
	Очередь = Новый Очередь();
	Очередь.Добавить("1");
	Очередь.Добавить("2");
	Очередь.Добавить("3");
	
	Очередь.Скопировать(Приемник,1);
	
	Ожидаем.Что(Приемник.Количество()).Равно(2);
КонецПроцедуры


Процедура Тест_Должен_ПолучитьХешКод() Экспорт
	
	// Некоторое непонимание по методу
	
	Очередь = Новый Очередь();
	Очередь.Добавить("1");
	Очередь.Добавить("2");
	Очередь.Добавить("3");
	
	ХешКод = Очередь.ПолучитьХешКод();
	Ожидаем.Что(ХешКод).Больше(0);
КонецПроцедуры


Процедура Тест_Должен_ВернутьПик() Экспорт
	
	Очередь = Новый Очередь();
	Очередь.Добавить("1");
	Очередь.Добавить("2");
	Очередь.Добавить("3");
	
	Пик = Очередь.Пик();
	Ожидаем.Что(Пик).Равно("1");
	Ожидаем.Что(Очередь.Количество()).Равно(3);
КонецПроцедуры


Процедура Тест_Должен_ВернутьПикПроверкаОшибки() Экспорт
	Очередь = Новый Очередь();
	Очередь.Добавить("1");
	Очередь.Добавить("2");
	Очередь.Добавить("3");
	
	Пик = Очередь.Пик();
	Ожидаем.Что(Пик).ЭтоНе().Равно("2");
	Ожидаем.Что(Очередь.Количество()).Равно(3);
КонецПроцедуры

Процедура Тест_Должен_ВМассив() Экспорт
	Очередь = Новый Очередь();
	Очередь.Добавить("1");
	Очередь.Добавить("2");
	Очередь.Добавить("3");
	
	Результат = Очередь.ВМассив();
	
	Ожидаем.Что(Результат.Количество()).Равно(3);
КонецПроцедуры


Процедура Тест_Должен_Обрезать() Экспорт
	
	// не понял как тестировать, просто проверяю падает или нет
	
	Очередь = Новый Очередь(20);
	Очередь.Добавить("1");
	Очередь.Добавить("2");
	Очередь.Добавить("3");
	
	Очередь.Обрезать();
	
КонецПроцедуры

Процедура Тест_Должен_Перебрать() Экспорт
	
	Очередь = Новый Очередь(20);
	Очередь.Добавить("Элемент1");
	Очередь.Добавить("Элемент2");
	Очередь.Добавить("Элемент3");
	
	СтрИтог = "";
	Для каждого Стр Из Очередь Цикл
		СтрИтог  = СтрИтог  + Стр;
	КонецЦикла;

	Ожидаем.Что(СтрИтог).Равно("Элемент1Элемент2Элемент3");
	
КонецПроцедуры

