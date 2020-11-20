import cv2
import numpy as np
from lib_detection import load_model, detect_lp, im2single
import os
import glob
import time
from flask import Flask
from flask import request, jsonify
from flask_cors import CORS, cross_origin
import base64
import _thread


# Khai bao cong cua server
my_port = '8000'

# Doan ma khoi tao server
app = Flask(__name__)
def load():

    wpod_net_path = "wpod-net_update1.json"
    wpod_net = load_model(wpod_net_path)
    return wpod_net
    
#app.before_first_request(load())
CORS(app)

os.environ['TF_CPP_MIN_LOG_LEVEL'] = '2'


# Ham sap xep contour tu trai sang phai
def sort_contours(cnts):

    reverse = False
    i = 0
    boundingBoxes = [cv2.boundingRect(c) for c in cnts]
    (cnts, boundingBoxes) = zip(*sorted(zip(cnts, boundingBoxes),
                                        key=lambda b: b[1][i], reverse=reverse))
    return cnts

# Dinh nghia cac ky tu tren bien so
char_list =  '0123456789ABCDEFGHKLMNPRSTUVXYZ'

# Ham fine tune bien so, loai bo cac ki tu khong hop ly
def fine_tune(lp):
    newString = ""
    for i in range(len(lp)):
        if lp[i] in char_list:
            newString += lp[i]
    return newString


def SVMsolution(rgb_img,threshold=[127,110,135,148,163,180,200,170,90],position='down'):
    model_svm = cv2.ml.SVM_load('svm.xml')
    digit_w = 30 
    digit_h = 60 
    dot = False
    plate=''
    gray = cv2.cvtColor( rgb_img, cv2.COLOR_BGR2GRAY)
    # Ap dung threshold de phan tach so va nen
    for i in threshold:
        print(i)
        binary= cv2.threshold(gray, i, 255,cv2.THRESH_BINARY_INV)[1]
        #cv2.imshow("Cac contour tim duoc", binary)
        #cv2.waitKey()
        dot = False 
        if (position == "up"):
            binary = binary[0:270,40:250]
        #cv2.imshow("Cac contour tim duoc1", binary)
        #cv2.waitKey()
    # Segment kí tự
        kernel3 = cv2.getStructuringElement(cv2.MORPH_RECT, (3, 3))
        thre_mor = cv2.morphologyEx(binary, cv2.MORPH_DILATE, kernel3)
        cont, _  = cv2.findContours(thre_mor, cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)[-2:]
        plate_info = ""
        #print("p "+position)
        try:
            for c in sort_contours(cont):
                (x, y, w, h) = cv2.boundingRect(c)   
                ratio = h/w
                
                
                
                if position=="down":
                    if 0.72<ratio<1.5 and 0.15>h/rgb_img.shape[0]>=0.075 :
                    
                    #   cv2.rectangle(rgb_img, (x, y), (x + w, y + h), (0, 255, 0), 2) 
                        dot = True
                       
              
                if 1.5<=ratio<=4.0: # Chon cac contour dam bao ve ratio w/h
                    if h/rgb_img.shape[0]>=0.6 and h/rgb_img.shape[0]<1.6 and w/rgb_img.shape[0] < 0.46: # Chon cac contour cao tu 60% bien so tro len
                #        print("bbb")
                        # Ve khung chu nhat quanh so
                        cv2.rectangle(rgb_img, (x, y), (x + w, y + h), (0, 255, 0), 2)
                        
                        
                        # Tach so va predict
                        curr_num = thre_mor[y:y+h,x:x+w]
                        curr_num = cv2.resize(curr_num, dsize=(digit_w, digit_h))
                        _, curr_num = cv2.threshold(curr_num, 30, 255, cv2.THRESH_BINARY)
                        curr_num = np.array(curr_num,dtype=np.float32)
                        curr_num = curr_num.reshape(-1, digit_w * digit_h)

                        # Dua vao model SVM
                        result = model_svm.predict(curr_num)[1]
                        result = int(result[0, 0])
                #        print(result)
                        if result<=9: # Neu la so thi hien thi luon
                            result = str(result)
                        else: #Neu la chu thi chuyen bang ASCII
                            result = chr(result)

                        plate_info +=result
            #cv2.imshow("Cac contour tim duoc", rgb_img)
            #cv2.waitKey()
        except:
            pass 
        #print(len(plate_info))
        print(plate_info)
        if (plate_info!=""):
            if (position =="up"):
                if (len(plate_info)>len(plate) and len(plate_info)>3):
                    plate=plate_info
            else:
                if (len(plate_info)>len(plate) and len(plate_info) < 6 and len(plate_info)>3):
                    plate=plate_info
            #print("plate :" + plate)
            if position=='up':
                if (len(plate) >= 3):
                    break
            else:
                plate=plate.replace("D","0")
                plate=plate.replace("B","8")
                plate=plate.replace("Z","2")
                if dot==True:
                    if (len(plate) == 5):
                        break
                else: 
                    if (len(plate) >= 4):
                        break

    #cv2.imshow("Cac contour tim duoc", rgb_img)
    #cv2.waitKey()

    return plate

def SVMsolutionCar(rgb_img,threshold=[127, 70, 90, 110, 150, 60, 50, 40]):
    model_svm = cv2.ml.SVM_load('svm.xml')
    digit_w = 30 
    digit_h = 60 
    dot = False
    plate=''
    gray = cv2.cvtColor( rgb_img, cv2.COLOR_BGR2GRAY)
    # Ap dung threshold de phan tach so va nen
    for i in threshold:
        print(i)
        binary= cv2.threshold(gray, i, 255,cv2.THRESH_BINARY_INV)[1]
        #cv2.imshow("Cac contour tim duoc", binary)
        #cv2.waitKey()
        dot = False 
        #cv2.imshow("Cac contour tim duoc1", binary)
        #cv2.waitKey()
    # Segment kí tự
        kernel3 = cv2.getStructuringElement(cv2.MORPH_RECT, (3, 3))
        thre_mor = cv2.morphologyEx(binary, cv2.MORPH_DILATE, kernel3)
        cont, _  = cv2.findContours(thre_mor, cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)[-2:]
        plate_info = ""
        #print("p "+position)
        try:
            for c in sort_contours(cont):
                (x, y, w, h) = cv2.boundingRect(c)   
                ratio = h/w
                #if 1<ratio < 3.4 and h/rgb_img.shape[0]>=0.2 and h/rgb_img.shape[0]<0.8: 
                #    print("filter")
                #    cv2.rectangle(rgb_img, (x, y), (x + w, y + h), (0, 255, 0), 2)
                #    print(w/rgb_img.shape[0])
                #    print(h/rgb_img.shape[0])
                #    print (ratio)
                if 1.3<=ratio<=4: # Chon cac contour dam bao ve ratio w/h
                    print(ratio)
                    print(w/rgb_img.shape[0])
                    print("rgb_img:")
                    print(h/rgb_img.shape[0])
                    if h/rgb_img.shape[0]>=0.55 and h/rgb_img.shape[0]<0.8: # Chon cac contour cao tu 60% bien so tro len
                #        print("bbb")
                        # Ve khung chu nhat quanh so
                        cv2.rectangle(rgb_img, (x, y), (x + w, y + h), (0, 255, 0), 2)
                        
                        
                        # Tach so va predict
                        curr_num = thre_mor[y:y+h,x:x+w]
                        curr_num = cv2.resize(curr_num, dsize=(digit_w, digit_h))
                        _, curr_num = cv2.threshold(curr_num, 30, 255, cv2.THRESH_BINARY)
                        curr_num = np.array(curr_num,dtype=np.float32)
                        curr_num = curr_num.reshape(-1, digit_w * digit_h)

                        # Dua vao model SVM
                        result = model_svm.predict(curr_num)[1]
                        result = int(result[0, 0])
                #        print(result)
                        if result<=9: # Neu la so thi hien thi luon
                            result = str(result)
                        else: #Neu la chu thi chuyen bang ASCII
                            result = chr(result)
                        print(result)
                        plate_info +=result
            #cv2.imshow("Cac contour tim duoc", rgb_img)
            #cv2.waitKey()
        except:
            pass 
        print(len(plate_info))
        print(plate_info)
        if (len(plate_info)>len(plate) and len(plate_info)>=7):
            plate=plate_info
            return plate
        

    #cv2.imshow("Cac contour tim duoc", rgb_img)
    #cv2.waitKey()

    return plate
    
def filebrowser(word=""):
    """Returns a list with all files with the word/extension in it"""
    file = []
    for f in glob.glob("Y:/Read/*/*.jpg"):
        if word in f:
            file.append(f)
    return file

wpod_net_path = "wpod-net_update1.json"
wpod_net = load_model(wpod_net_path)

def go(rtsp):
    global plt
    plt=[0,0,0,0]
    while(1):
        
        plt[rtsp] = plt[rtsp]+1
        plt[1] = 1

#graph = tf.get_default_graph()

# Khai bao ham xu ly request hello_word
@app.route('/getPlateNumber', methods=['GET'])
@cross_origin()
def getPlateNumber():
    try:
        #wpod_net_path = "wpod-net_update1.json"
        #wpod_net = load_model(wpod_net_path)
    # Lay staff id cua client gui len
        image = request.args.get('imagepath')
        #image ="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"
        #image=image.replace(" ","+")
        #decoded_data = base64.b64decode(image)
        #np_data = np.fromstring(decoded_data,np.uint8)
        #Ivehicle = cv2.imdecode(np_data,cv2.IMREAD_UNCHANGED)
        Ivehicle = cv2.imread(str(image))
        #cv2.imshow("test", Ivehicle)
        #cv2.waitKey(0)
        #Ivehicle =Ivehicle[100:,:,:] 
        Dmax = 608
        Dmin = 288
        ratio = float(max(Ivehicle.shape[:2])) / min(Ivehicle.shape[:2])
        side = int(ratio * Dmin)
        bound_dim = min(side, Dmax)
        
        _ , LpImg, lp_type = detect_lp(wpod_net, im2single(Ivehicle), bound_dim, lp_threshold=0.5)
        
       
        if (len(LpImg)):
            LpImg[0] = cv2.convertScaleAbs(LpImg[0], alpha=(255.0))
            #cv2.imshow("Anh bien so", LpImg[0])
            if lp_type == 1:              
                plt = SVMsolutionCar(LpImg[0])
            else:
                #cv2.imshow("Anh",LpImg[0][100:])
                plt=SVMsolution(LpImg[0][0:95],position='up') + "-"+SVMsolution(LpImg[0][95:],position='down')
            cv2.destroyAllWindows()
    # Tra ve cau chao Hello
            if (len(plt)<2):
                plt="khong bien so"
            return plt
    except:
        cv2.destroyAllWindows()
        return "khong bien so"

#number_detect()
# Thuc thi server




#file = filebrowser()
#number_detect()
if __name__ == '__main__':
    #app.
    #app.before_first_request(load())
    app.run(threaded=True,debug=True, host='0.0.0.0',port=my_port)