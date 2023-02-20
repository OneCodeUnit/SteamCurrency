Программа, которая сможет ответить на вопрос "Сколько придёт мне на Steam, если я отправлю себе сейчас через Qiwi?"

## Системные требования
Для запуска требуется [.Net SDK, Runtime или Desktop Runtime](https://dotnet.microsoft.com/en-us/download).
Он существует в трёх вариантах:
+ SDK - запуск и разработка приложений
+ Runtime - только запуск приложений
+ Desktop Runtime - только запуск настольных приложений для Windows.

Для Windows 7 и 8.1 подойдёт только .Net 6, а для Windows 10 (версия 1607+) и 11 (версия 22000+) можно установить .Net 7.

## Работа программы
Программа через Rest-запросы узнаёт у Steam (окольными путями) и Qiwi (через API) курсы валют и производит вычисления суммы, которая поступит, и суммы, которую "съест" конвертация. Из-за способа получения курсов у Steam, присутствует погрешность на уровне 1 рубля.

## Обратите внимание
+ Курсы у Steam и Qiwi отличаются от биржевых, поэтому их необходимо узнавать.
+ Курс стима считается через сравнение цен на торговой площадки у одного и того же товара. Возможно, если более правильный способ, но он мне неизвестен. 
+ Цены на торговой площадке округлены до двух знаков после запятой, что приводит к погрешностям при вычислениях.
+ Иногда программа может не получить или получить неправильные курсы (Steam как всегда). Подождите некоторое время и попробуйте снова.
+ Не стоит проверять курсы слишком часто (речь о десятках раз в час), так как это может привести к бану по IP. 

## Будущие нововведения
+ улучшить код
+ добавить кеширование курсов валюты

### Заходите на сервер [Vanilla Russian Expanded](https://discord.gg/GB2e2VhgVE), посвященный RimWorld, модам и переводам.
