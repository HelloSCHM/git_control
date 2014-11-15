import urllib.request 
import re

f = open('url.txt','w')
def getName():
    name = input('请输入小说名：')
    fname = str(name.encode('gb2312'))
    fname = re.sub("\\\\x","%",fname)
    fname = re.sub("b'|'","",fname)
    url = "http://www.23us.com/modules/article/search.php?&charset=utf-8articlename=&searchkey="
    url += fname
    return url
def getHtml(url):
    page = urllib.request.urlopen(url)
    html = page.read()
    html = html.decode('GBK')
    return html
def getUrl(html):
    reg = r"(?<=<a class=\"read\" href=\")\S+\b"
    urlget = re.compile(reg)
    urlg = re.findall(urlget,html)
    for index,item in enumerate(urlg):
        f.write(item)
    truenovelurl = urlg[0]
    return truenovelurl

try:
    trueurl = getUrl(getHtml(getName()))
    #print(getUrl(getHtml(getName())))
    print(trueurl)  
    f.close()
except ZeroDivisionError:
    print('输入小说未找到，请检查后重试~')
