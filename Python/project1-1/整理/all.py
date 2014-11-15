import urllib.request 
import re
import os
import shutil
import sys,time
name = input('请输入小说名：')
#temp = os.mkdir('temp')
def getHtml(url):
    page = urllib.request.urlopen(url)
    html = page.read()
    html = html.decode('GBK')
    return html
try:
    f = open('url.dat','w')
    def getName():
        fname = str(name.encode('gb2312'))
        fname = re.sub("\\\\x","%",fname)
        fname = re.sub("b'|'","",fname)
        url = "http://www.23us.com/modules/article/search.php?&charset=utf-8articlename=&searchkey="
        url += fname
        return url
    def getUrl(html):
        reg = r"(?<=<a class=\"read\" href=\")\S+\b"
        urlget = re.compile(reg)
        urlg = re.findall(urlget,html)
        for index,item in enumerate(urlg):
            f.write(item)
        truenovelurl = urlg[0] 
        return urlg
    trueurl = getUrl(getHtml(getName()))[0]
    #print(getUrl(getHtml(getName())))
    print(trueurl)
    f.close()
    
except ZeroDivisionError:
    print('输入小说未找到，请检查后重试~')

try:
    f = open('temp.dat','w')
    #f.write(html + "\n\n")
    html = getHtml(trueurl)
    reg = r"(?<=<td class=\"L\">)[\s\S]*(?=</a></td>)"
    urlget = re.compile(reg)
    urlg = re.findall(urlget,html)
    for index,item in enumerate(urlg):
        #print (index,item)
        f.write(item)
    f.write('</a></td>')
    f.close()
except ZeroDivisionError:
    print('未获取有效信息，请检查后重试~')

try:
    f = open('temp.dat','r')
    ff = open('temp2.dat','w')
    #f.write(html + "\n\n")
    html = f.read()
    reg = r"(?<=<a href=\")\S+(?=\">)|(?<=.html\">)[\s\S]*?(?=</a></td>)"
    urlget = re.compile(reg)
    urlg = re.findall(urlget,html)
    for index,item in enumerate(urlg):
        #print (index,item)
        ff.write(item + '\n')
    print('已获取章节信息')
    f.close()
    ff.close()
except ZeroDivisionError:
    print('未获取有效信息，请检查后重试~')

try:
    listall = []
    listurl = []
    listname = []
    file = open('temp2.dat','r')
    f = open('f1.txt','w')
    ff = open('f2.txt','w')
    fff = open('url.dat')
    url = fff.read()
    for index,item in enumerate(file):
          if index % 2 == 0:
                listurl.append(url + '/' + item.strip('\n'))
                f.write(url + '/' + item.strip('\n') + '\n')
          else:
                listname.append(item.strip('\n'))
                ff.write(item.strip('\n') + '\n')
          #print(item.strip('\n'))
    f.close()
    ff.close()
except ZeroDivisionError:
    print('未获取有效信息，请检查后重试~')

try:
      if os.path.exists(name):
            print('文件已存在')
      else:
            os.mkdir(name)
except ZeroDivisionError:
    print('文件已存在，请删除后继续~')
#os.chdir(name)
#basepath = 'c:\data';

def getNovel(url):
      html = getHtml(url)
      html = re.sub("<br /><br />|&nbsp;|<br />|&amp;","",html)
      reg = r"(?<=<dd id=\"contents\">)[\s\S]*(?=</dd>\s)"
      urlget = re.compile(reg)
      urlg = re.findall(urlget,html)
      html = urlg[0]
      return html

j = '#'
fall = open(name + '.txt','a')
for index,item in enumerate(listname):
    if index%30 == 0:
        j += '#'
    else:
        pass
    #print(index,len(listname))
    num = round(index/len(listname)*100,2)
    sys.stdout.write(str(num)+'%  ||'+ j + '->'+"\r")
    sys.stdout.flush()

#for line in open('f2.txt'):
    basename = item.strip()
    basename = re.sub('[｛/\:*?"<>|｝]','',basename)
    #print(listurl[index])
    if os.path.exists(name + '\\' + basename + '.txt'):
        pass
        #print('已存在正在跳过')
    else:
        if index%30 == 0:
            time.sleep(5)
        else:
            file = open(name + '\\' + basename + '.txt','w')
            novel = basename + '\n' + getNovel(listurl[index])
            file.write(novel)
            fall.write(novel + '\n\n')
            file.close()
            time.sleep(0.5)


fall.close()
