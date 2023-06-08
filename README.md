Программа, которая сможет ответить на вопрос "Сколько придёт мне на Steam, если я отправлю себе сейчас через Qiwi или WebMoney?"

## Системные требования (основная версия программы)
Для запуска требуется [.Net 7](https://dotnet.microsoft.com/en-us/download). Подойдёт любой вариант: SDK, Runtime или Desktop Runtime.

Поддерживается Windows 10 (версия 1607) и новее.

[Скачать программу](https://github.com/OneCodeUnit/SteamCurrency/releases/latest) (загружать SteamCurrency.exe)

## Системные требования (legacy версия программы)
Если у вас Windows 10 (версия 1903) и новее, то ничего дополнительного не потребуется. Если старше до Windows 7 включительно, то для запуска требуется [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework). Подойдёт вариант Runtime.

[Скачать программу](https://github.com/OneCodeUnit/SteamCurrency/releases/latest) (загружать SteamCurrencyLegacy.zip)

## Работа программы
Программа через Rest-запросы узнаёт у Steam, WebMoney (окольными путями) и Qiwi (через API) курсы валют и производит вычисления суммы, которая поступит, и суммы, которую "съест" конвертация. Из-за способа получения курсов у Steam, присутствует погрешность на уровне 1 рубля.

Программа сохраняет курсы с предыдущего запуска и может производить расчёты по ним без подключения к интернету.

## Обратите внимание
+ Курсы у Steam и Qiwi и WebMoney отличаются от биржевых, поэтому их необходимо узнавать.
+ Курс стима считается через сравнение цен на торговой площадке у одного и того же товара. Возможно, есть более правильный способ, так как цены на торговой площадке округлены до двух знаков после запятой, что приводит к погрешностям при вычислениях.
+ Подсказка к вводимой сумме отображается с округлением до двух знаков после запятой, что соответствует точности поля ввода на сайте Qiwi.
+ Qiwi конвертирует тенге в доллары по курсу, который примерно на 4% выше того, о котором он сообщает. Я не знаю, почему так. Вариант с дополнительной валютой не подходит. Однако программа учитывает этот процент при вычислениях.
+ Курс WebMoney берется на основе самого выгодного P2P-предложения, которое предполагает определенный объем сделки. Предложение для вашего объема может иметь менее выгодный курс. Программа это не учитывает.
+ WebMoney имеет комиссию 4% на пополнение Steam. Программа это учитывает.
+ Существует вероятность, что программа может не получить или получить неправильные курсы. Подождите некоторое время и попробуйте снова.
+ Не стоит проверять курсы слишком часто (речь о десятках раз в час), так как это может привести к временному бану по IP.
+ Курс должен быть наиболее выгодным во время торгов на бирже, то есть днём в будние дни.

## Заходите на сервер [Vanilla Russian Expanded](https://discord.gg/GB2e2VhgVE), посвященный RimWorld, модам и переводам.
