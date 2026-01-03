# Deep Learning Inference as API Service on local computer

This is an introduction of how to run deep learning inference with python on Windows
---
- Step 1. install python 
    - download python installer from https://www.python.org/downloads/windows/
    - run the python installer
    - open cmd, enter  python --version to check python version
    - in cmd, enter pip --version to check pip version
- Step 2. install torch
    - pip install torch torchvision torchaudio --index-url https://download.pytorch.org/whl/cu118
    - open cmd, enter import torch
    - in cmd, print(torch.cuda.is_available())
    - if show tru, then NVIDIA GPU is available
- Step 3a. run classify inference with GPU (resnet50)
    - download inference_GPU.py
    - download cat.jpg and put aside py file
    - open cmd, enter python inference_GPU.py
    - it will print tabby, which is correct result
- Step 3b. run classify inference with CPU
    - download inference_CPU.py
    - download cat.jpg and put aside py file
    - open cmd, enter python inference_CPU.py
    - it will print tabby, which is correct result
- Step 3c. run object detection inference with GPU (resnet 50 fpn)
    - download objectDetection_inference.py
    - download cat.jpg and put aside py file
    - open cmd, enter python objectDetection_inference.py
    - it will print several object detections result with class name cat
- Step 4. install fast api
    - open cmd, enter pip install fastapi uvicorn pillow torch torchvision
    - in cmd, enter pip install python-multipart
    - download classify_api.py
    - in cmd, enter uvicorn classify_api:app --reload --host 127.0.0.1 --port 8000
    - an api service will launch on your local computer
    - open http://127.0.0.1:8000/docs in browser
    - on the website, upload cat.jpg image, and click Execute to test the api
    - you will get class name tabby response

This is an introduction of how to build windows UI program (C# winform) to run image classify with python api serivce
---

- Step 1. setup c# environment
    - install microsoft visual studio 2022 https://visualstudio.microsoft.com/zh-hant/vs/community/
    - create a new winform project Windows Form App (.NET Framework)
    - Open Nuget manager, and download Newtonsoft.json
- Step 2. download DLInspect folder
- Step 3. build and run
    - click load image, program will call previous open python classify api and get classify result
<img width="742" height="478" alt="image" src="https://github.com/user-attachments/assets/671bb94d-e2f3-4754-95a7-3e10437ab6b6" />

- 
