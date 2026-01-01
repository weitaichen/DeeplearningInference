from fastapi import FastAPI, File, UploadFile
from fastapi.responses import JSONResponse
from PIL import Image
import torch
from torchvision import models, transforms

# ---------------------------
# Load pretrained model (ResNet50)
# ---------------------------
device = torch.device("cuda" if torch.cuda.is_available() else "cpu")
weights = models.ResNet50_Weights.DEFAULT
model = models.resnet50(weights=weights)
model.eval().to(device)
preprocess = weights.transforms()

# ---------------------------
# FastAPI setup
# ---------------------------
app = FastAPI(title="Image Classification API")

# ---------------------------
# API endpoint
# ---------------------------
@app.post("/classify")
async def classify_image(file: UploadFile = File(...)):
    try:
        # Load image
        img = Image.open(file.file).convert("RGB")
        input_tensor = preprocess(img).unsqueeze(0).to(device)

        # Inference
        with torch.no_grad():
            outputs = model(input_tensor)
            probabilities = torch.nn.functional.softmax(outputs[0], dim=0)
            class_id = probabilities.argmax().item()
            class_name = weights.meta["categories"][class_id]
            confidence = probabilities[class_id].item()

        # Return JSON
        return JSONResponse({
            "class_id": class_id,
            "class_name": class_name,
            "confidence": confidence
        })
    except Exception as e:
        return JSONResponse({"error": str(e)}, status_code=500)