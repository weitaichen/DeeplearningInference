import torch
from torchvision import models, transforms
from PIL import Image

# Load pretrained model
weights = models.ResNet50_Weights.DEFAULT
model = models.resnet50(weights=weights)
model.eval()

# Image preprocessing
preprocess = weights.transforms()

# Load image
img = Image.open("cat.jpg").convert("RGB")
input_tensor = preprocess(img).unsqueeze(0)

# Inference
with torch.no_grad():
    outputs = model(input_tensor)

# Get top prediction
probabilities = torch.nn.functional.softmax(outputs[0], dim=0)
top1 = probabilities.argmax().item()

# Class label
label = weights.meta["categories"][top1]

print(f"Predicted class: {label}")