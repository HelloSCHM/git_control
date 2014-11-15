# -*- coding:utf-8 -*-
import urllib.request
import re
import os
 
def getHtml(url):
    page = urllib.request.urlopen(url)
    html = page.read()
    html = html.decode('utf-8')
    return html

def getName(html):
    regs = r'<h1 class="core_title_txt  \" title="(.*?)\"'
    namel = re.compile(regs)
    name = re.findall(namel,html)[0]
    if os.path.exists(name):
        print('文件已存在')
    else:
        os.mkdir(name)
        os.chdir(name)
    return name

def getImg(html,x,i): 
    reg = r"<img class=\"BDE_Image\" src=\"(.*?\.jpg)\""
    #此处为正则表达式，用于匹配页面中的图片链接，不同的网页图片链接的格式有所不用，此处需按需调整
    imgre = re.compile(reg)
    imglist = re.findall(imgre,html)

    for imgurl in imglist:
        if os.path.exists('%s.jpg' % x ):
            pass
        else:
            urllib.request.urlretrieve(imgurl,'%s-%s.jpg' %(i,x))
            print ("第",x,"张下载完成！")
            x+=1
    return x

def baidu_tieba(url,begin_pn,end_pn):
    url = re.sub("b'|'","",url)
    html = getHtml(url + str(1))
    name = getName(html)
    for i in range(begin_pn, end_pn+1):
        if i == 0:
            os.chdir(str(name))
        else:
            pass
        print(name)
        url = re.sub("b'|'","",url)
        print(url + str(i))
        html = getHtml(url + str(i))
        #print html
        #name = getName(html)       
        getImg(html,x,i)
#将图片所在网页链接放入此处，大部分在WINDOWS下使用，所以不采用变量传入的方式
x = 1
url = input('输入需要获取的网页地址截止为pn：')
url = str(url.encode('utf-8'))
begin_pn = input('输入开始页：')
#begin_pn = str(begin_pn.encode('utf-8'))
end_pn = input('输入结束页：')
#end_pn = str(end_pn.encode('utf-8'))
baidu_tieba(url,int(begin_pn),int(end_pn))
