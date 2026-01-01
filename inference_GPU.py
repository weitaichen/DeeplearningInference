import torch
from torchvision import models
from PIL import Image

device = torch.device("cuda" if torch.cuda.is_available() else "cpu")
print("Using device:", device)

# Load model
weights = models.ResNet50_Weights.DEFAULT
model = models.resnet50(weights=weights)
model = model.to(device)
model.eval()

# Preprocess
preprocess = weights.transforms()
img = Image.open("cat.jpg").convert("RGB")
input_tensor = preprocess(img).unsqueeze(0).to(device)

# Inference
with torch.no_grad():
    outputs = model(input_tensor)

# Prediction
pred = outputs.argmax(dim=1).item()
label = weights.meta["categories"][pred]

print("Predicted class:", label)