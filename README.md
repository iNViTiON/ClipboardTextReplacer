# ClipboardTextReplacer

Automatic replace text in clipboard with another text for Windows.

e.g. copy `https://www.facebookwkhpilnemxj7asaniu7vnjjbiltxjqhye3mhbshg7kx5tfyd.onion` and get `https://www.facebook.com` in clipboard.

Advance regex text replace can use to strip tracking query param from url. [query param list here](Program.cs#L96-L113)

### Example

#### Facebook
```
https://www.facebook.com/facebookcorewwwi/posts/pfbid0ekRfSNJAynHTQkgHd7F3n9CdutckYt6jomBf6r9Kfj68Q7nZ1WeLDAks57AZjeEpl?__cft__[0]=AZW2tok2MJV_-COmmtzi2y_9frEXRGg4Uamt6nhDhsiNelMriyV_8eRevDN_BVFRkmz6H1omjqd0450s-sGmXbT_XrR28mG_oyITa4rD-SY1b8iujzJsI7c-ZTnI0M0RLNeJxSAv49-z8kPcOwv0zz_LZvIUMjYcx-c4zfjPWydKJeavwTetD2vDrXh-sQbrN4M&__tn__=%2CO%2CP-R&type=3&hoisted_section_header_type=header&sfnsn=1
```
to
```
https://www.facebook.com/facebookcorewwwi/posts/pfbid0ekRfSNJAynHTQkgHd7F3n9CdutckYt6jomBf6r9Kfj68Q7nZ1WeLDAks57AZjeEpl?type=3
```
#### Facebook Onion

```
https://www.facebookwkhpilnemxj7asaniu7vnjjbiltxjqhye3mhbshg7kx5tfyd.onion/photo/?fbid=10160497233918708&set=a.464184773707&notif_id=1658063510889953&notif_t=feedback_reaction_generic&ref=notif
```
to
```
https://www.facebook.com/photo/?fbid=10160497233918708&set=a.464184773707
```

#### Twitter | Twitter Onion

```
https://twitter.com/Twitter/status/1509206476874784769?t=xnSc6C0qmYaIu6BVsQeJ-w&s=19
```
to
```
https://twitter.com/Twitter/status/1509206476874784769
```

 #### Lazada
```
https://www.lazada.co.th/products/microsoft-surface-slim-pen-2-not-include-slim-pen-charger-i3354599645-s12446444292.html?clickTrackInfo=query%253Asurface%252Bslim%252Bpen%252B2%253Bnid%253A3354599645%253Bsrc%253ALazadaMainSrp%253Brn%253Ab306ac14c9bc553ad8361eba52a205b2%253Bregion%253Ath%253Bsku%253A3354599645_TH%253Bprice%253A4750.00%253Bclient%253Adesktop%253Bsupplier_id%253A100179033810%253Basc_category_id%253A14365%253Bitem_id%253A3354599645%253Bsku_id%253A12446444292%253Bshop_id%253A892503&search=1&spm=a2o4m.searchlist.list.3
```
to
```
https://www.lazada.co.th/i3354599645.html
```

#### Shopee
```
https://shopee.co.th/Microsoft-Surface-Slim-Pen-2(not-include-Slim-Pen-Charger)-i.233973765.12374567450?sp_atk=2ab7004b-93de-4ae5-a830-30a5442f100a&xptdk=2ab7004b-93de-4ae5-a830-30a5442f100a
```
to
```
https://shopee.co.th/s-i.233973765.12374567450
```
