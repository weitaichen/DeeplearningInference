# Deeplearning Inference

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
