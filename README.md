# ClipboardTextReplacer

Automatic replace text in clipboard with another text for Windows.

e.g. copy `https://www.facebookwkhpilnemxj7asaniu7vnjjbiltxjqhye3mhbshg7kx5tfyd.onion` and get `https://www.facebook.com` in clipboard.

Advance regex text replace can use to strip tracking query param from url. [query param list here](Program.cs#L96-L113)

### Example

```
https://www.facebook.com/facebookcorewwwi/posts/pfbid0ekRfSNJAynHTQkgHd7F3n9CdutckYt6jomBf6r9Kfj68Q7nZ1WeLDAks57AZjeEpl?__cft__[0]=AZW2tok2MJV_-COmmtzi2y_9frEXRGg4Uamt6nhDhsiNelMriyV_8eRevDN_BVFRkmz6H1omjqd0450s-sGmXbT_XrR28mG_oyITa4rD-SY1b8iujzJsI7c-ZTnI0M0RLNeJxSAv49-z8kPcOwv0zz_LZvIUMjYcx-c4zfjPWydKJeavwTetD2vDrXh-sQbrN4M&__tn__=%2CO%2CP-R&type=3&hoisted_section_header_type=header&sfnsn=1
```
||  
V
```
https://www.facebook.com/facebookcorewwwi/posts/pfbid0ekRfSNJAynHTQkgHd7F3n9CdutckYt6jomBf6r9Kfj68Q7nZ1WeLDAks57AZjeEpl?type=3
```
and

```
https://www.facebookwkhpilnemxj7asaniu7vnjjbiltxjqhye3mhbshg7kx5tfyd.onion/photo/?fbid=10160497233918708&set=a.464184773707&notif_id=1658063510889953&notif_t=feedback_reaction_generic&ref=notif
```
||  
V
```
https://www.facebook.com/photo/?fbid=10160497233918708&set=a.464184773707
```
and

```
https://twitter.com/Twitter/status/1509206476874784769?t=xnSc6C0qmYaIu6BVsQeJ-w&s=19
```

||  
V
```
https://twitter.com/Twitter/status/1509206476874784769
```