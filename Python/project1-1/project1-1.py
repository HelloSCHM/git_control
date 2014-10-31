import urllib.request 
import re

def getHtml(url):
    page = urllib.request.urlopen(url)
    html = page.read()
    return html
def getUrl(html):
    reg = r"(?<=<a href="")\d\S+(?="">)|(?<="">)\w+\s\w+"
    urlget = re.compile(reg)
    urlg = re.findall(urlget,html)
    return urlg
    
html = getHtml("http://www.23us.com/html/28/28373/")
print (getHtml(html))
