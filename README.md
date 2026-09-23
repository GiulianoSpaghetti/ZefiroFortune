Il primo vero fortune teller italiano copiato nel framework zafiro.
La particolarità di questo framework  che ammette solo l'MVUX, quindi è stato un pratico esercizio di sviluppo: a me non è costato niente, ma serve come esempio per studiarsi la programmazione con zafiro.


# Come ottenere
## Per android
[![google](https://play.google.com/intl/it_it/badges/static/images/badges/en_badge_web_generic.png)](https://play.google.com/store/apps/details?id=org.altervista.numerone.fortune.zefiro&pli=1)


## Per windows

### Per x64
Basta inserire nella lista dei repository winget il mio repository personale, disponibile all'indirizzo

       https://numeronesoft.ddns.net/net11/api

### Per ARM64
Sta sul mio onedrive, contatttate il mio manager della numeronesoft per accederci

## Per Debian
Usate il mio repository.

    https://numeronesoft.ddns.net
# La personalizzazione delle icone in zafiro
Zafiro, al contrario di material, permette di utlizzare delle icone per indicare le pagine nei menù.
E' installato il pacchetto Optris.Icons.Avalonia.FontAwesome, vi passo il link alle icone contenute nel pacchettO: https://optris.github.io/Optris.Icons.Avalonia/
Basta sostituire nel viewmodel della pagina fa:home col relativo nome, per esempio fa:firefox o fa:info.
Esiste il pacchetto fontawesone7 ed il pacchetto material design, che vanno installati a mano e vanno inizializzati nell'app.axml.cs, come descrive il manuale.
Ecco alcuni esempi

<img width="902" height="632" alt="Screenshot 2026-09-23 220940" src="https://github.com/user-attachments/assets/ce4e9c09-eae8-4c87-9a02-4c79efca01f6" />
<img width="902" height="632" alt="Screenshot 2026-09-23 215555" src="https://github.com/user-attachments/assets/e339f747-ca09-47b9-9151-716178bd8438" />
<img width="902" height="632" alt="Screenshot 2026-09-23 221601" src="https://github.com/user-attachments/assets/1f9de44e-e365-4eb2-a73c-3c96f818f961" />

